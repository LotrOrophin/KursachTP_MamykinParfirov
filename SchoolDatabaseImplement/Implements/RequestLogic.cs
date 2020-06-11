using Microsoft.EntityFrameworkCore;
using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.Enums;
using AbstractSchoolBusinessLogic.Interfaces;
using AbstractSchoolBusinessLogic.ViewModels;
using SchoolDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;

namespace SchoolDatabaseImplement.Implements
{
    public class RequestLogic : IRequestLogic
    {
        public void CreateOrUpdate(RequestBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Request request;
                        if (model.Id.HasValue)
                        {
                            request = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);
                            if (request == null)
                            {
                                throw new Exception("Заявка не найдена");
                            }
                            var requestSchoolSupplie = context.RequestsSchoolSupplies
                                .Where(rec => rec.RequestId == model.Id.Value).ToList();
                            context.RequestsSchoolSupplies.RemoveRange(requestSchoolSupplie.Where(rec =>
                                !model.SchoolSupllies.ContainsKey(rec.SchoolSupplieId)).ToList());
                            foreach (var updSchoolSupplie in requestSchoolSupplie)
                            {
                                updSchoolSupplie.Count = model.SchoolSupllies[updSchoolSupplie.SchoolSupplieId].Item2;
                                updSchoolSupplie.Inres = model.SchoolSupllies[updSchoolSupplie.SchoolSupplieId].Item3;
                                model.SchoolSupllies.Remove(updSchoolSupplie.SchoolSupplieId);
                            }
                            context.SaveChanges();
                        }
                        else
                        {
                            request = new Request();
                            context.Requests.Add(request);
                        }
                        request.SupplierId = model.SupplierId;
                        request.Sum = model.Sum;
                        request.CreationDate = model.CreationDate;
                        request.Status = model.Status;
                        context.SaveChanges();
                        foreach (var SchoolSupplie in model.SchoolSupllies)
                        {
                            context.RequestsSchoolSupplies.Add(new RequestSchoolSupplie
                            {
                                RequestId = request.Id,
                                SchoolSupplieId = SchoolSupplie.Key,
                                Count = SchoolSupplie.Value.Item2,
                                Inres = false
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

        public void Delete(RequestBindingModel model)
        {
            if (model.Status != RequestStatus.Выполняется)
            {
                using (var context = new SchoolDatabase())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.RequestsSchoolSupplies.RemoveRange(context
                                .RequestsSchoolSupplies.Where(rec => rec.RequestId == model.Id));
                            Request request = context.Requests.FirstOrDefault(rec => rec.Id == model.Id);
                            if (request != null)
                            {
                                context.Requests.Remove(request);
                                context.SaveChanges();
                            }
                            else
                            {
                                throw new Exception("Такой заявки нет");
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
            else
            {
                throw new Exception("Заявка в состоянии выполнения, удаление невозможно");
            }
        }

        public List<RequestViewModel> Read(RequestBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                return context.Requests
                    .Include(rec => rec.Supplier)
                    .Where(rec => model == null || rec.Id == model.Id || (rec.SupplierId == model.SupplierId) && (model.DateFrom == null && model.DateTo == null ||
                    rec.CompletionDate >= model.DateFrom && rec.CompletionDate <= model.DateTo && rec.Status == RequestStatus.Готова))
                    .ToList()
                    .Select(rec => new RequestViewModel
                    {
                        Id = rec.Id,
                        SupplierFIO = rec.Supplier.SupplierFIO,
                        Status = rec.Status,
                        CompletionDate = rec.CompletionDate,
                        CreationDate = rec.CreationDate,
                        SupplierId = rec.SupplierId,
                        SchoolSupplies = context.RequestsSchoolSupplies
                            .Include(recRF => recRF.SchoolSupplie)
                            .Where(recRF => recRF.RequestId == rec.Id)
                            .ToDictionary(recRF => recRF.SchoolSupplieId, recRF =>
                            (recRF.SchoolSupplie?.SchoolSupplieName, recRF.Count, recRF.Inres)),
                        Sum = Decimal.Round(context.RequestsSchoolSupplies
                            .Include(recRF => recRF.SchoolSupplie)
                            .Where(recRF => recRF.RequestId == rec.Id)
                            .Sum(recRF => recRF.SchoolSupplie.Price * recRF.Count), 2)
                    })
                    .ToList();
            }
        }
        public void Reserve(ReserveSchoolSuppliesBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                var requestFoods = context.RequestsSchoolSupplies.FirstOrDefault(rec =>
                rec.RequestId == model.RequestId && rec.SchoolSupplieId == model.SchoolSupplieId);
                if (requestFoods == null)
                {
                    throw new Exception("Товара нет в заявке");
                }
                requestFoods.Inres = true;
                context.SaveChanges();
            }
        }

        public void SaveJsonRequest(string folderName)
        {
            string fileName = $"{folderName}\\Request.json";
            using (var context = new SchoolDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<Request>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.Requests);
                }
            }
        }

        public void SaveJsonRequestSchoolSupplie(string folderName)
        {
            string fileName = $"{folderName}\\RequestSchoolSupplie.json";
            using (var context = new SchoolDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<RequestSchoolSupplie>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.RequestsSchoolSupplies);
                }
            }
        }
        public void SaveXmlRequest(string folderName)
        {
            string fileNameDop = $"{folderName}\\Request.xml";
            using (var context = new SchoolDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<Request>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.Requests);
                }
            }
        }
        public void SaveXmlRequestSchoolSupplie(string folderName)
        {
            string fileNameDop = $"{folderName}\\RequestSchoolSupplie.xml";
            using (var context = new SchoolDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<RequestSchoolSupplie>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.RequestsSchoolSupplies);
                }
            }
        }
    }
}