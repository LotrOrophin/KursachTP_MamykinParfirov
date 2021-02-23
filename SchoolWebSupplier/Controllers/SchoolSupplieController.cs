using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchoolWebSupplier.Controllers
{
    public class SchoolSupplieController : Controller
    {
        private readonly ISchoolSupplieLogic schoolSupplieLogic;

        public SchoolSupplieController(ISchoolSupplieLogic schoolSupplieLogic)
        {
            this.schoolSupplieLogic = schoolSupplieLogic;
        }

        public IActionResult ListSchoolSupplies(int wareHouseId)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            ViewBag.wareHouseId = wareHouseId;
            return View(schoolSupplieLogic.Read(null));
        }

        public IActionResult AddSchoolSupplie(int? SchoolSupplieId, int? WareHouseId)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            if (SchoolSupplieId == null && WareHouseId == null)
            {
                return NotFound();
            }
            if (TempData["ErrorLackInWareHouse"] != null)
            {
                ModelState.AddModelError("", TempData["ErrorLackInWareHouse"].ToString());
            }
            var schoolSupplie = schoolSupplieLogic.Read(new SchoolSupplieBindingModel
            {
                Id = SchoolSupplieId
            })?[0];
            if (schoolSupplie == null)
            {
                return NotFound();
            }
            ViewBag.SchoolSupplieName = schoolSupplie.SchoolSupplieName;
            ViewBag.WareHouseId = WareHouseId;
            return View(new RequestSchoolSupplieBindingModel
            {
                SchoolSupplieId = WareHouseId.Value,
                WareHouseId = WareHouseId.Value,
            });
        }
    }
}
