using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.HelperModels;
using AbstractSchoolBusinessLogic.Interfaces;
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
        public SupplierReportLogic(IRequestLogic requestLogic)
        {
            this.requestLogic = requestLogic;
        }

        public Dictionary<int, (string, int, bool)> GetRequestFoods(int requestId)
        {
            var requestFoods = requestLogic.Read(new RequestBindingModel
            {
                Id = requestId
            })?[0].SchoolSupplies;
            return requestFoods;
        }

        public void SaveNeedFoodToWordFile(WordInfo wordInfo, string email)
        {
            string title = "Список требуемых продуктов по заявке №" + wordInfo.RequestId;
            wordInfo.Title = title;
            wordInfo.FileName = wordInfo.FileName;
            wordInfo.DateComplete = DateTime.Now;
            wordInfo.RequestSchoolSupplies = GetRequestFoods(wordInfo.RequestId);
            SupplierSaveToWord.CreateDoc(wordInfo);
            SendMail(email, wordInfo.FileName, title);
        }

        public void SaveNeedFoodToExcelFile(ExcelInfo excelInfo, string email)
        {
            string title = "Список требуемых продуктов по заявке №" + excelInfo.RequestId;
            excelInfo.Title = title;
            excelInfo.FileName = excelInfo.FileName;
            excelInfo.DateComplete = DateTime.Now;
            excelInfo.SchoolSupplies = GetRequestFoods(excelInfo.RequestId);
            SupplierSaveToExcel.CreateDoc(excelInfo);
            SendMail(email, excelInfo.FileName, title);
        }

        public void SendMail(string email, string fileName, string subject)
        {
            MailAddress from = new MailAddress("denis_73007@mail.ru", "Школа");
            MailAddress to = new MailAddress(email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Attachments.Add(new Attachment(fileName));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("denis_73007@mail.ru", "987-654lL");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
