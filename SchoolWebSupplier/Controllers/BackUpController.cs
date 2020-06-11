using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AbstractSchoolBusinessLogic.BusinessLogics;
using AbstractSchoolBusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolWebSupplier.Controllers
{
    public class BackUpController : Controller
    {
        private readonly IRequestLogic _request;
        private readonly IWareHouseLogic _wareHouse;
        private readonly ISupplierLogic _supplier;
        private readonly ISchoolSupplieLogic _schoolSupplie;
        private readonly SupplierReportLogic _supplierReport;
        public BackUpController(IRequestLogic request, IWareHouseLogic wareHouse, ISupplierLogic supplier, ISchoolSupplieLogic schoolSupplie, SupplierReportLogic supplierReport)
        {
            _request = request;
            _wareHouse = wareHouse;
            _supplier = supplier;
            _schoolSupplie = schoolSupplie;
            _supplierReport = supplierReport;
        }
        public IActionResult BackUp()
        {
            return View();
        }
        public IActionResult BackUpToJson()
        {
            string fileName = "E:\\BackupJson";
            if (Directory.Exists(fileName))
            {
                _request.SaveJsonRequest(fileName);
                _request.SaveJsonRequestSchoolSupplie(fileName);
                _wareHouse.SaveJsonWareHouse(fileName);
                _wareHouse.SaveJsonWareHouseSchoolSupplie(fileName);
                _supplier.SaveJsonSupplier(fileName);
                _schoolSupplie.SaveJsonSchoolSupplie(fileName);
                _supplierReport.SendMailBackup("denis_73007@mail.ru", fileName, "Бэкап Json", "json");
                return RedirectToAction("BackUp");
            }
            else
            {
                return RedirectToAction("BackUp");
            }
        }
        public IActionResult BackUpToXml()
        {
            string fileName = "E:\\BackupXml";
            if (Directory.Exists(fileName))
            {
                _request.SaveXmlRequest(fileName);
                _request.SaveXmlRequestSchoolSupplie(fileName);
                _wareHouse.SaveXmlWareHouse(fileName);
                _wareHouse.SaveXmlWareHouseSchoolSupplie(fileName);
                _supplier.SaveXmlSupplier(fileName);
                _schoolSupplie.SaveXmlSchoolSupplie(fileName);
                _supplierReport.SendMailBackup("denis_73007@mail.ru", fileName, "Бэкап Xml", "xml");
                return RedirectToAction("BackUp");
            }
            else
            {
                return RedirectToAction("BackUp");
            }
        }
    }
}
