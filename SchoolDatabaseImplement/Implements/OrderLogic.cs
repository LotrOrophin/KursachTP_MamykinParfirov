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
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                Order element;
                if (model.Id.HasValue)
                {
                    element = context.Orders.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Order();
                    context.Orders.Add(element);
                }
                element.CircleId = model.CircleId == 0 ? element.CircleId : model.CircleId;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.OrderStatus = model.OrderStatus;
                element.CreationDate = model.CreationDate;
                element.CompletionDate = model.CompletionDate;
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new SchoolDatabase())
            {
                return context.Orders
            .Include(rec => rec.Circle)
            .Where(
                    rec => model == null
                    || (rec.Id == model.Id && model.Id.HasValue)
                    || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.CreationDate >= model.DateFrom && rec.CreationDate <= model.DateTo))
            .Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                CircleName = rec.Circle.CircleName,
                Count = rec.Count,
                Sum = rec.Circle.PricePerHour,
                OrderStatus = rec.OrderStatus,
                CreationDate = rec.CreationDate,
                CompletionDate = rec.CompletionDate
            })
            .ToList();
            }
        }

        public void SaveJson(string folderName)
        {
            string fileName = $"{folderName}\\order.json";
            using (var context = new SchoolDatabase())
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Order>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, context.Orders);
                }
            }
        }

        public void SaveXml(string folderName)
        {
            string fileName = $"{folderName}\\order.xml";
            using (var context = new SchoolDatabase())
            {
                XmlSerializer fomatter = new XmlSerializer(typeof(DbSet<Order>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    fomatter.Serialize(fs, context.Orders);
                }
            }
        }
    }
}