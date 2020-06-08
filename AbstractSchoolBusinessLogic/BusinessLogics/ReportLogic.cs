using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.BusinessLogic;
using AbstractSchoolBusinessLogic.HelperModels;
using AbstractSchoolBusinessLogic.Interfaces;
using AbstractSchoolBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace AbstractSchoolBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly ICircleLogic circleLogic;
        private readonly IOrderLogic orderLogic;
        private readonly IWareHouseLogic warehouseLogic;

        public ReportLogic(ICircleLogic circleLogic, IOrderLogic orderLogic, IWareHouseLogic warehouseLogic)
        {
            this.circleLogic = circleLogic;
            this.orderLogic = orderLogic;
            this.warehouseLogic = warehouseLogic;
        }

        public List<ReportCircleSchoolSupplieViewModel> GetCircleSchoolSupplies()
        {
            var circles = circleLogic.Read(null);
            var list = new List<ReportCircleSchoolSupplieViewModel>();
            foreach (var circle in circles)
            {
                foreach (var pc in circle.CircleSchoolSupplies)
                {
                    var record = new ReportCircleSchoolSupplieViewModel
                    {
                        CircleName = circle.CircleName,
                        SchoolSupplieName = pc.Value.Item1,
                        Count = pc.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }

        public List<ReportWareHouseSchoolSupplieViewModel> GetWarehouseSchoolSupplie()
        {
            var warehouses = warehouseLogic.Read(null);
            var list = new List<ReportWareHouseSchoolSupplieViewModel>();
            foreach (var warehouse in warehouses)
            {
                foreach (var ff in warehouse.SchoolSupplies)
                {
                    var record = new ReportWareHouseSchoolSupplieViewModel
                    {
                        WarehouseName = warehouse.WareHouseName,
                        SchoolSupplieName = ff.Value.Item1,
                        Count = ff.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }

        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic
            .Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .GroupBy(rec => rec.CreationDate.Date)
            .OrderBy(recG => recG.Key)
            .ToList();
            return list;
        }
        public List<ReportOrdersViewModel> GetOrder(ReportBindingModel model)
        {
            return orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                CreationDate = x.CreationDate,
                CircleName = x.CircleName,
                Count = x.Count,
                Amount = x.Sum,
                Status = x.Status
            })
            .ToList();
        }
        public List<ReportOrdersViewModel> GetReportOrder(ReportBindingModel model)
        {
            var orders = orderLogic.Read(null);
            var list = new List<ReportOrdersViewModel>();
            foreach (var order in orders)
            {
                var record = new ReportOrdersViewModel
                {
                    CircleName = order.CircleName,
                    Amount = order.Sum,
                    Count = order.Count,
                    CreationDate = order.CreationDate,
                    Status = order.Status
                };
                list.Add(record);
            }
            return list;
        }
        public void SaveOrdersToWordFile(ReportBindingModel model)
        {
            try
            {
                SaveToWord.CreateDoc(new WordInfo
                {
                    FileName = model.FileName,
                    Title = "Список выполненных заказов",
                    Orders = GetReportOrder(model),
                    CircleSchoolSupplies = GetCircleSchoolSupplies()
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void SaveCirclesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список кружков",
                Circles = circleLogic.Read(null),
                Warehouses = null
            });
        }

        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список выполненных заказов",
                Orders = GetReportOrder(model),
                CircleSchoolSupplies = GetCircleSchoolSupplies()
            });
        }

        public void SaveCirclesSchoolSuppliesToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список кружков по канцелярии",
                SchoolSuppliesCircles = GetCircleSchoolSupplies(),
                WarehouseSchoolSupplies = null
            });
        }
        public void SendMail(string email, string fileName, string subject)
        {
            MailAddress from = new MailAddress("denis_73007@mail.ru", "Школа");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Attachments.Add(new Attachment(fileName));
            SmtpClient smtp = new SmtpClient("detark322@gmail.com", 587);
            smtp.Credentials = new NetworkCredential("denis_73007@mail.ru", "1");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }

    }
}
