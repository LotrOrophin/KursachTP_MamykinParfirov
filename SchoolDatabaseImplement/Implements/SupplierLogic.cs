using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.Interfaces;
using AbstractSchoolBusinessLogic.ViewModels;
using Microsoft.EntityFrameworkCore;
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
    public class SupplierLogic : ISupplierLogic
    {
        public void CreateOrUpdate(SupplierBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                Supplier element = context.Suppliers.FirstOrDefault(rec => rec.Email == model.Login && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Эта почта уже используется");
                }
                if (model.Id.HasValue)
                {
                    element = context.Suppliers.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Поставщик не найден");
                    }
                }
                else
                {
                    element = new Supplier();
                    context.Suppliers.Add(element);
                }
                element.SupplierFIO = model.SupplierFIO;
                element.Email = model.Login;
                element.Password = model.Password;
                context.SaveChanges();
            }
        }

        public void Delete(SupplierBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                Supplier element = context.Suppliers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Suppliers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Поставщик не найден");
                }
            }
        }

        public List<SupplierViewModel> Read(SupplierBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                return context.Suppliers
                .Where(rec => model == null || rec.Id == model.Id || ((rec.Email == model.Login) &&
                 (rec.Password == model.Password)))
                .Select(rec => new SupplierViewModel
                {
                    Id = rec.Id,
                    SupplierFIO = rec.SupplierFIO,
                    Email = rec.Email,
                    Password = rec.Password
                })
                .ToList();
            }
        }
        public void SaveJsonSupplier(string folderName)
        {
            string fileName = $"{folderName}\\Supplier.json";
            using (var context = new SchoolDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(IEnumerable<Supplier>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.Suppliers);
                }
            }
        }

        public void SaveXmlSupplier(string folderName)
        {
            string fileNameDop = $"{folderName}\\Supplier.xml";
            using (var context = new SchoolDatabase())
            {
                XmlSerializer fomatterXml = new XmlSerializer(typeof(DbSet<Supplier>));
                using (FileStream fs = new FileStream(fileNameDop, FileMode.Create))
                {
                    fomatterXml.Serialize(fs, context.Suppliers);
                }
            }
        }
    }
}