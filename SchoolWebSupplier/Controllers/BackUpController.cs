﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AbstractSchoolBusinessLogic.BusinessLogics;
using AbstractSchoolBusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MigraDoc.Rendering;

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
            //Directory.CreateDirectory("F:\\BackupJson");
            //System.IO.File.Create("F:\\BackupJson\\BackupJson.json");
            string fileName = "F:\\BackupJson";
            if (Directory.Exists(fileName))
            {
                _request.SaveJsonRequest(fileName);
                _request.SaveJsonRequestSchoolSupplie(fileName);
                _wareHouse.SaveJsonWareHouse(fileName);
                _wareHouse.SaveJsonWareHouseSchoolSupplie(fileName);
                _supplier.SaveJsonSupplier(fileName);
                _schoolSupplie.SaveJsonSchoolSupplie(fileName);
                _supplierReport.SendMailBackup("mamykinvladimir00@gmail.com", fileName, "Бэкап Json", "json");
                return RedirectToAction("BackUp");
            }
            else
            {
                return RedirectToAction("BackUp");
            }
        }
        public IActionResult BackUpToXml()
        {
            Directory.CreateDirectory("F:\\BackupXml");
            System.IO.File.Create("F:\\BackupXml\\BackupXml.Xml");
            string fileName = "F:\\BackupXml";
            if (Directory.Exists(fileName))
            {
                _request.SaveXmlRequest(fileName);
                _request.SaveXmlRequestSchoolSupplie(fileName);
                _wareHouse.SaveXmlWareHouse(fileName);
                _wareHouse.SaveXmlWareHouseSchoolSupplie(fileName);
                _supplier.SaveXmlSupplier(fileName);
                _schoolSupplie.SaveXmlSchoolSupplie(fileName);
                _supplierReport.SendMailBackup("mamykinvladimir00@gmail.com", fileName, "Бэкап Xml", "xml");
                return RedirectToAction("BackUp");
            }
            else
            {
                return RedirectToAction("BackUp");
            }
        }
    }
}
