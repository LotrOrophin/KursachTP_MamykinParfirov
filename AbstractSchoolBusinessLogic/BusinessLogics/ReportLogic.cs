using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.BusinessLogic;
using AbstractSchoolBusinessLogic.Enums;
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
        private readonly ISchoolSupplieLogic schoolSupplieLogic;
        private readonly IRequestLogic requestLogic;

        public ReportLogic(ICircleLogic circleLogic, IOrderLogic orderLogic, IRequestLogic requestLogic, ISchoolSupplieLogic schoolSupplieLogic)
        {
            this.circleLogic = circleLogic;
            this.orderLogic = orderLogic;
            this.requestLogic = requestLogic;
            this.schoolSupplieLogic = schoolSupplieLogic;
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
        public List<ReportSchoolSupplieViewModel> GetSchoolSupplies(DateTime from, DateTime to)
        {
            var schoolSupplies = schoolSupplieLogic.Read(null);
            var requests = requestLogic.Read(null);
            var list = new List<ReportSchoolSupplieViewModel>();
            foreach (var request in requests)
            {
                if (request.CreationDate >= from && request.CreationDate <= to)
                {
                    foreach (var requestSchoolSupplie in request.SchoolSupplies)
                    {
                        foreach (var schoolSupplie in schoolSupplies)
                        {
                            if (schoolSupplie.SchoolSupplieName == requestSchoolSupplie.Value.Item1)
                            {
                                var record = new ReportSchoolSupplieViewModel
                                {
                                    SchoolSupplieName = requestSchoolSupplie.Value.Item1,
                                    Count = requestSchoolSupplie.Value.Item2,
                                    Status = StatusSchoolSupplie(request.Status),
                                    CompletionDate = DateTime.Now,
                                    PricePerHour = schoolSupplie.Price
                                };
                                list.Add(record);
                            }
                        }
                    }
                }
            }
            return list;
        }
        public string StatusSchoolSupplie(RequestStatus requestStatus)
        {
            if (requestStatus == RequestStatus.Создана)
                return "Ждут отправки";
            if (requestStatus == RequestStatus.Выполняется)
                return "В пути";
            if (requestStatus == RequestStatus.Готова)
                return "Поставлено";
            if (requestStatus == RequestStatus.Обработана)
                return "Использовано";
            return "";
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
                    OrderStatus = order.OrderStatus
                };
                list.Add(record);
            }
            return list;
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
            SendMail("kristina.zolotareva.14@gmail.com", model.FileName, "Список блюд с продуктами");
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
            SendMail("kristina.zolotareva.14@gmail.com", model.FileName, "Список кружков с канцелярией");
        }
        public void SaveSchoolSuppliesToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Отчет по движению канцелярии",
                SchoolSupplies = GetSchoolSupplies(model.DateFrom, model.DateTo),
                DateTo = model.DateTo,
                DateFrom = model.DateFrom
            });
            SendMail("mamykinvladimir00@gmail.com", model.FileName, "Отчет по движению канцелярии");
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
        public void SendMailReport(string email, string fileName, string subject, string type)
        {
            MailAddress from = new MailAddress("labwork15kafis@gmail.com", "Школа");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Attachments.Add(new Attachment(fileName + "\\Order." + type));
            m.Attachments.Add(new Attachment(fileName + "\\Request." + type));
            m.Attachments.Add(new Attachment(fileName + "\\RequestSchoolSupplie." + type));
            m.Attachments.Add(new Attachment(fileName + "\\Circle." + type));
            m.Attachments.Add(new Attachment(fileName + "\\CircleSchoolSupplie." + type));
            m.Attachments.Add(new Attachment(fileName + "\\SchoolSupplie." + type));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("labwork15kafis@gmail.com", "passlab15");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
