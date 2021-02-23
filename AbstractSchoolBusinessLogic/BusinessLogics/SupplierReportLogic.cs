using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.Enums;
using AbstractSchoolBusinessLogic.HelperModels;
using AbstractSchoolBusinessLogic.Interfaces;
using AbstractSchoolBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AbstractSchoolBusinessLogic.BusinessLogics
{
    public class SupplierReportLogic
    {
        private readonly IRequestLogic requestLogic;
        private readonly ISchoolSupplieLogic schoolSupplieLogic;
        public SupplierReportLogic(IRequestLogic requestLogic, ISchoolSupplieLogic schoolSupplieLogic)
        {
            this.requestLogic = requestLogic;
            this.schoolSupplieLogic = schoolSupplieLogic;
        }

        public Dictionary<int, (string, int, bool)> GetRequestSchoolSupplies(int requestId)
        {
            var requestFoods = requestLogic.Read(new RequestBindingModel
            {
                Id = requestId
            })?[0].SchoolSupplies;
            return requestFoods;
        }
        public List<ReportSchoolSupplieViewModel> GetSchoolSupplies(RequestBindingModel model)
        {
            var schoolSupplies = schoolSupplieLogic.Read(null);
            var requests = requestLogic.Read(model);
            var list = new List<ReportSchoolSupplieViewModel>();
            foreach (var request in requests)
            {
                foreach (var requestFood in request.SchoolSupplies)
                {
                    foreach (var schoolSupplie in schoolSupplies)
                    {
                        if (schoolSupplie.SchoolSupplieName == requestFood.Value.Item1)
                        {
                            var record = new ReportSchoolSupplieViewModel
                            {
                                RequestId = request.Id,
                                SupplierFIO = request.SupplierFIO,
                                SchoolSupplieName = requestFood.Value.Item1,
                                Count = requestFood.Value.Item2,
                                Status = StatusSchoolSupplie(request.Status),
                                CompletionDate = request.CompletionDate,
                                PricePerHour = schoolSupplie.Price,
                                Sum = request.Sum
                            };
                            list.Add(record);
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
        public void SaveNeedSchoolSupplieToWordFile(WordInfo wordInfo, string email)
        {
            string title = "Список требуемых продуктов по заявке №" + wordInfo.RequestId;
            wordInfo.Title = title;
            wordInfo.FileName = wordInfo.FileName;
            wordInfo.RequestSchoolSupplies = GetRequestSchoolSupplies(wordInfo.RequestId);
            SupplierSaveToWord.CreateDoc(wordInfo);
            SendMail(email, wordInfo.FileName, title);
        }

        public void SaveNeedSchoolSupplieToExcelFile(ExcelInfo excelInfo, string email)
        {
            string title = "Список требуемых продуктов по заявке №" + excelInfo.RequestId;
            excelInfo.Title = title;
            excelInfo.FileName = excelInfo.FileName;
            excelInfo.RequestSchoolSupplies = GetRequestSchoolSupplies(excelInfo.RequestId);
            SupplierSaveToExcel.CreateDoc(excelInfo);
            SendMail(email, excelInfo.FileName, title);
        }
        public void SaveSchoolSuppliesToPdfFile(string fileName, RequestBindingModel model, string email)
        {
            string title = "Список канцелярии в период с " + model.DateFrom.ToString() + " по " + model.DateTo.ToString();
            SupplierSaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = fileName,
                Title = title,
                SchoolSupplies = GetSchoolSupplies(model)
            });
            SendMail(email, fileName, title);
        }
        public void SendMail(string email, string fileName, string subject)
        {
            MailAddress from = new MailAddress("testkursach322@mail.ru", "Школа");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Attachments.Add(new Attachment(fileName));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("testkursach322@mail.ru", "987-654lL");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }

        public void SendMailBackup(string email, string fileName, string subject, string type)
        {
            MailAddress from = new MailAddress("testkursach322@mail.ru", "Школа");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Attachments.Add(new Attachment(fileName + "\\Request." + type));
            m.Attachments.Add(new Attachment(fileName + "\\RequestSchoolSupplie." + type));
            m.Attachments.Add(new Attachment(fileName + "\\WareHouse." + type));
            m.Attachments.Add(new Attachment(fileName + "\\WareHouseSchoolSupplie." + type));
            m.Attachments.Add(new Attachment(fileName + "\\Supplier." + type));
            m.Attachments.Add(new Attachment(fileName + "\\SchoolSupplie." + type));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("testkursach322@mail.ru", "987-654lL");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
