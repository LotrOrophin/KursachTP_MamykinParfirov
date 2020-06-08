using Microsoft.EntityFrameworkCore;
using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.Interfaces;
using AbstractSchoolBusinessLogic.ViewModels;
using SchoolDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace SchoolDatabaseImplement.Implements
{
    public class SchoolSupplieLogic : ISchoolSupplieLogic
    {
        public void CreateOrUpdate(SchoolSupplieBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                SchoolSupplie element = context.SchoolSupplies.FirstOrDefault(rec =>
               rec.SchoolSupplieName == model.SchoolSupplieName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Такой канц. товар уже добавлен");
                }
                if (model.Id.HasValue)
                {
                    element = context.SchoolSupplies.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new SchoolSupplie();
                    context.SchoolSupplies.Add(element);
                }
                element.SchoolSupplieName = model.SchoolSupplieName;
                element.Price = model.Price;
                context.SaveChanges();
            }
        }
        public void Delete(SchoolSupplieBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                SchoolSupplie element = context.SchoolSupplies.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.SchoolSupplies.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<SchoolSupplieViewModel> Read(SchoolSupplieBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                return context.SchoolSupplies
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new SchoolSupplieViewModel
                {
                    Id = rec.Id,
                    SchoolSupplieName = rec.SchoolSupplieName,
                    Price = rec.Price
                })
                .ToList();
            }
        }

        public void SaveJson(string folderName)
        {
            string fileName = $"{folderName}\\schoolSupplie.json";
            using (var context = new SchoolDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<SchoolSupplie>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.SchoolSupplies);
                }
            }
        }

        public void SaveXml(string folderName)
        {
            string fileName = $"{folderName}\\schoolSupplie.xml";
            using (var context = new SchoolDatabase())
            {
                XmlSerializer fomatter = new XmlSerializer(typeof(DbSet<SchoolSupplie>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    fomatter.Serialize(fs, context.SchoolSupplies);
                }
            }
        }
    }
}