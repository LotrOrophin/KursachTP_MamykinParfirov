using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.BusinessLogics;
using AbstractSchoolBusinessLogic.HelperModels;
using AbstractSchoolBusinessLogic.Interfaces;
using AbstractSchoolBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolWebSupplier.Models;

namespace SchoolWebSupplier.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestLogic requestLogic;
        private readonly IWareHouseLogic wareHouseLogic;
        private readonly SupplierBusinessLogic supplierLogic;
        private readonly SupplierReportLogic reportLogic;
        private readonly ISchoolSupplieLogic schoolSupplieLogic;
        public RequestController(IRequestLogic requestLogic, IWareHouseLogic wareHouseLogic, SupplierBusinessLogic supplierLogic, SupplierReportLogic reportLogic, ISchoolSupplieLogic schoolSupplieLogic)
        {
            this.requestLogic = requestLogic;
            this.wareHouseLogic = wareHouseLogic;
            this.supplierLogic = supplierLogic;
            this.reportLogic = reportLogic;
            this.schoolSupplieLogic = schoolSupplieLogic;
        }

        public IActionResult Request()
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            var requests = requestLogic.Read(new RequestBindingModel
            {
                SupplierId = Program.Supplier.Id
            });
            return View(requests);
        }

        public IActionResult Report(ReportModel model)
        {
            var requests = new List<RequestViewModel>();
            requests = requestLogic.Read(new RequestBindingModel
            {
                SupplierId = Program.Supplier.Id,
                DateFrom = model.From,
                DateTo = model.To
            });
            ViewBag.Requests = requests;
            string fileName = "F:\\Reportpdf.pdf";
            if (model.SendMail)
            {
                reportLogic.SaveSchoolSuppliesToPdfFile(fileName, new RequestBindingModel
                {
                    SupplierId = Program.Supplier.Id,
                    DateFrom = model.From,
                    DateTo = model.To
                }, Program.Supplier.Email);
            }
            return View();
        }

        public IActionResult RequestView(int ID)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            if (TempData["ErrorFoodReserve"] != null)
            {
                ModelState.AddModelError("", TempData["ErrorSchoolSupplieReserve"].ToString());
            }
            ViewBag.RequestID = ID;
            var schoolsupplies = requestLogic.Read(new RequestBindingModel
            {
                Id = ID
            })?[0].SchoolSupplies;
            return View(schoolsupplies);
        }

        public IActionResult Reserve(int requestId, int schoolSupplieId)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            supplierLogic.ReserveSchoolSupplies(new ReserveSchoolSuppliesBindingModel
            {
                RequestId = requestId,
                SchoolSupplieId = schoolSupplieId
            });
            return RedirectToAction("RequestView", new { id = requestId });
        }

        public IActionResult AcceptRequest(int id)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            supplierLogic.AcceptRequest(new ChangeRequestStatusBindingModel
            {
                RequestId = id
            });
            return RedirectToAction("Request");
        }

        public IActionResult CompleteRequest(int id)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            supplierLogic.CompleteRequest(new ChangeRequestStatusBindingModel
            {
                RequestId = id
            });
            return RedirectToAction("Request");
        }

        public IActionResult ListSchoolSupplieAvailable(int id, int count, string name, int requestId)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            ViewBag.FoodName = name;
            ViewBag.Count = count;
            ViewBag.SchoolSupplieId = id;
            ViewBag.RequestId = requestId;
            var warehouses = wareHouseLogic.GetWareHouseAvailable(new RequestSchoolSupplieBindingModel
            {
                SchoolSupplieId = id,
                Count = count
            });
            return View(warehouses);
        }
        public IActionResult SendWordReport(int id)
        {
            string fileName = "F:\\" + id + ".docx";
            reportLogic.SaveNeedSchoolSupplieToWordFile(new WordInfo
            {
                FileName = fileName,
                RequestId = id,
                SupplierFIO = Program.Supplier.SupplierFIO
            }, Program.Supplier.Email);
            return RedirectToAction("Request");
        }
        public IActionResult SendExcelReport(int id)
        {
            string fileName = "F:\\" + id + ".xlsx";
            reportLogic.SaveNeedSchoolSupplieToExcelFile(new ExcelInfo
            {
                FileName = fileName,
                RequestId = id,
                SupplierFIO = Program.Supplier.SupplierFIO
            }, Program.Supplier.Email);
            return RedirectToAction("Request");
        }
    }
}
