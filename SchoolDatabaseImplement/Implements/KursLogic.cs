using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.Interfaces;
using AbstractSchoolBusinessLogic.ViewModels;
using SchoolDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Xml.Serialization;

namespace SchoolDatabaseImplement.Implements
{
    public class KursLogic : IOrderLogic
    {
        public void CreateOrUpdate(KursBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                Kurs element;
                if (model.Id.HasValue)
                {
                    element = context.Kurses.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Kurs();
                    context.Kurses.Add(element);
                }
                element.CircleId = model.CircleId == 0 ? element.CircleId : model.CircleId;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.KursStatus = model.KursStatus;
                element.CreationDate = model.CreationDate;
                element.CompletionDate = model.CompletionDate;
                context.SaveChanges();
            }
        }
        public void Delete(KursBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                Kurs element = context.Kurses.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Kurses.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<KursViewModel> Read(KursBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                return context.Kurses
            .Include(rec => rec.Circle)
            .Where(
                    rec => model == null
                    || (rec.Id == model.Id && model.Id.HasValue)
                    || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.CreationDate >= model.DateFrom && rec.CreationDate <= model.DateTo))
            .Select(rec => new KursViewModel
            {
                Id = rec.Id,
                CircleName = rec.Circle.CircleName,
                Count = rec.Count,
                Sum = rec.Circle.PricePerHour,
                KursStatus = rec.KursStatus,
                CreationDate = rec.CreationDate,
                CompletionDate = rec.CompletionDate
            })
            .ToList();
            }
        }

        public void SaveJsonOrder(string folderName)
        {
            string fileName = $"{folderName}\\Kurs.json";
            using (var context = new SchoolDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Kurs>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.Kurses);
                }
            }
        }

        public void SaveXmlOrder(string folderName)
        {
            string fileName = $"{folderName}\\Kurs.xml";
            using (var context = new SchoolDatabase())
            {
                XmlSerializer fomatter = new XmlSerializer(typeof(DbSet<Kurs>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    fomatter.Serialize(fs, context.Kurses);
                }
            }
        }
    }
}