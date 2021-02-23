using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.ViewModels;
using AbstractSchoolBusinessLogic.Interfaces;
using SchoolDatabaseImplement.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Xml.Serialization;

namespace SchoolDatabaseImplement.Implements
{
    public class CircleLogic : ICircleLogic
    {
        public void CreateOrUpdate(CircleBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Circle element = context.Circles.FirstOrDefault(rec =>
                       rec.CircleName == model.CircleName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть изделие с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Circles.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Circle();
                            context.Circles.Add(element);
                        }
                        element.CircleName = model.CircleName;
                        element.PricePerHour = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var CircleSchoolSupplies = context.CircleSchoolSupplies.Where(rec
                           => rec.CircleId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели
                            context.CircleSchoolSupplies.RemoveRange(CircleSchoolSupplies.Where(rec =>
                            !model.CircleSchoolSupplies.ContainsKey(rec.SchoolSupplieId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateSchoolSupplie in CircleSchoolSupplies)
                            {
                                updateSchoolSupplie.Count =
                               model.CircleSchoolSupplies[updateSchoolSupplie.SchoolSupplieId].Item2;

                                model.CircleSchoolSupplies.Remove(updateSchoolSupplie.SchoolSupplieId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.CircleSchoolSupplies)
                        {
                            context.CircleSchoolSupplies.Add(new CircleSchoolSupplie
                            {
                                CircleId = element.Id,
                                SchoolSupplieId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
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
        public void Delete(CircleBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // удаяем записи по продуктам при удалении закуски
                        context.CircleSchoolSupplies.RemoveRange(context.CircleSchoolSupplies.Where(rec =>
                        rec.CircleId == model.Id));
                        Circle element = context.Circles.FirstOrDefault(rec => rec.Id
                        == model.Id);
                        if (element != null)
                        {
                            context.Circles.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
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
        public List<CircleViewModel> Read(CircleBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                return context.Circles.Where(rec => model == null || rec.Id == model.Id)
                .ToList()
                .Select(rec => new CircleViewModel
                {
                    Id = rec.Id,
                    CircleName = rec.CircleName,
                    PricePerHour = rec.PricePerHour,
                    CircleSchoolSupplies = context.CircleSchoolSupplies.Include(recPC => recPC.SchoolSupplie)
                                                           .Where(recPC => recPC.CircleId == rec.Id)
                                                           .ToDictionary(recPC => recPC.SchoolSupplieId, recPC => (recPC.SchoolSupplie?.SchoolSupplieName, recPC.Count))
                }).ToList();
            }
        }
        public void SaveJsonCircle(string folderName)
        {
            string fileName = $"{folderName}\\Circle.json";
            using (var context = new SchoolDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<Circle>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.Circles);
                }
            }
        }

        public void SaveJsonCircleSchoolSupplie(string folderName)
        {
            string fileName = $"{folderName}\\CircleSchoolSupplie.json";
            using (var context = new SchoolDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<CircleSchoolSupplie>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.CircleSchoolSupplies);
                }
            }
        }

        public void SaveXmlCircle(string folderName)
        {
            string fileName = $"{folderName}\\Circle.xml";
            using (var context = new SchoolDatabase())
            {
                XmlSerializer fomatter = new XmlSerializer(typeof(DbSet<Circle>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    fomatter.Serialize(fs, context.Circles);
                }
            }
        }

        public void SaveXmlCircleSchoolSupplie(string folderName)
        {
            string fileName = $"{folderName}\\CircleSchoolSupplie.xml";
            using (var context = new SchoolDatabase())
            {
                XmlSerializer fomatter = new XmlSerializer(typeof(DbSet<CircleSchoolSupplie>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    fomatter.Serialize(fs, context.CircleSchoolSupplies);
                }
            }
        }
    }
}
