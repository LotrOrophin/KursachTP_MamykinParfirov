using Microsoft.EntityFrameworkCore;
using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.Interfaces;
using AbstractSchoolBusinessLogic.ViewModels;
using SchoolDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolDatabaseImplement.Implements
{
    public class WareHouseLogic : IWareHouseLogic
    {
        public List<WareHouseViewModel> Read(WareHouseBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                return context.WareHouses
                .Where(rec => model == null || rec.Id == model.Id
                    || rec.SupplierId == model.SupplierId)
                .ToList()
                .Select(rec => new WareHouseViewModel
                {
                    Id = rec.Id,
                    WareHouseName = rec.WareHouseName,
                    Size = rec.Size,
                    Type = rec.Type,
                    SchoolSupplies = context.WareHouseSchoolSupplies
                            .Include(recCC => recCC.SchoolSupplie)
                            .Where(recCC => recCC.WareHouseId == rec.Id)
                            .ToDictionary(recCC => recCC.SchoolSupplieId, recCC =>
                            (recCC.SchoolSupplie?.SchoolSupplieName, recCC.Free, recCC.IsReserved))
                })
                    .ToList();
            }
        }

        public void CreateOrUpdate(WareHouseBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                WareHouse element = context.WareHouses.FirstOrDefault(rec => rec.WareHouseName == model.WareHouseName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Склад с таким именем уже есть !!!!");
                }
                if (model.Id.HasValue)
                {
                    element = context.WareHouses.FirstOrDefault(rec => rec.Id == model.Id);
                    int free = context.WareHouseSchoolSupplies.Where(rec =>
                    rec.WareHouseId == model.Id).Sum(rec => rec.Free);
                    int res = context.WareHouseSchoolSupplies.Where(rec =>
                    rec.WareHouseId == model.Id).Sum(rec => rec.IsReserved);
                    if ((free + res) > model.Size)
                    {
                        throw new Exception("Размерность меньше количества имеющихся канц. товаров");
                    }
                    if (element == null)
                    {
                        throw new Exception("Склада с таким именем не существует");
                    }
                }
                else
                {
                    element = new WareHouse();
                    context.WareHouses.Add(element);
                }
                element.SupplierId = model.SupplierId;
                element.WareHouseName = model.WareHouseName;
                element.Size = model.Size;
                element.Type = model.Type;
                context.SaveChanges();
            }
        }

        public void Delete(WareHouseBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.WareHouseSchoolSupplies.RemoveRange(context.WareHouseSchoolSupplies.Where(rec => rec.WareHouseId == model.Id));
                        WareHouse element = context.WareHouses.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.WareHouses.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Склада с таким именем не существует");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<WareHouseAvailableViewModel> GetWareHouseAvailable(RequestSchoolSupplieBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                return context.WareHouseSchoolSupplies
                .Include(rec => rec.WareHouse)
                .Where(rec => rec.WareHouseId == model.SchoolSupplieId
                && rec.Free >= model.Count)
                .Select(rec => new WareHouseAvailableViewModel
                {
                    WareHouseId = rec.WareHouseId,
                    WareHouseName = rec.WareHouse.WareHouseName,
                    Count = rec.Free
                })
                .ToList();
            }
        }

        public void AddSchoolSupplie(RequestSchoolSupplieBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                var wareHouseSchoolSupplies = context.WareHouseSchoolSupplies.FirstOrDefault(rec =>
                 rec.WareHouseId == model.WareHouseId && rec.WareHouseId == model.WareHouseId);
                var wareHouse = context.WareHouses.FirstOrDefault(rec => rec.Id == model.WareHouseId);

                int free = context.WareHouseSchoolSupplies.Where(rec =>
                rec.WareHouseId == model.WareHouseId).Sum(rec => rec.Free);
                int res = context.WareHouseSchoolSupplies.Where(rec =>
                rec.WareHouseId == model.WareHouseId).Sum(rec => rec.IsReserved);
                if ((free + res + model.Count) > wareHouse.Size)
                {
                    throw new Exception("Недостаточно места в на складе");
                }
                if (wareHouseSchoolSupplies == null)
                {
                    context.WareHouseSchoolSupplies.Add(new WareHouseSchoolSupplie
                    {
                        WareHouseId = model.WareHouseId,
                        SchoolSupplieId = model.SchoolSupplieId,
                        Free = model.Count,
                        IsReserved = 0
                    });
                }
                else
                {
                    wareHouseSchoolSupplies.Free += model.Count;
                }
                context.SaveChanges();
            }
        }

        public void ReserveSchoolSupplies(RequestSchoolSupplieBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                var wareHouseSchoolSupplies = context.WareHouseSchoolSupplies.FirstOrDefault(rec =>
                rec.WareHouseId == model.WareHouseId && rec.WareHouseId == model.WareHouseId);
                if (wareHouseSchoolSupplies != null)
                {
                    if (wareHouseSchoolSupplies.Free >= model.Count)
                    {
                        wareHouseSchoolSupplies.Free -= model.Count;
                        wareHouseSchoolSupplies.IsReserved += model.Count;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Не хватает товаров для резервирования");
                    }
                }
                else
                {
                    throw new Exception("На складе нет таких товаров");
                }
            }
        }
    }
}