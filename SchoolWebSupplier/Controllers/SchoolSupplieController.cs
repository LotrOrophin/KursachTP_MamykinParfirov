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

        public IActionResult ListFoods(int fridgeId)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            ViewBag.fridgeId = fridgeId;
            return View(schoolSupplieLogic.Read(null));
        }

        public IActionResult AddFood(int? FoodId, int? FridgeId)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            if (FoodId == null && FridgeId == null)
            {
                return NotFound();
            }
            if (TempData["ErrorLackInFridge"] != null)
            {
                ModelState.AddModelError("", TempData["ErrorLackInFridge"].ToString());
            }
            var food = schoolSupplieLogic.Read(new SchoolSupplieBindingModel
            {
                Id = FoodId
            })?[0];
            if (food == null)
            {
                return NotFound();
            }
            ViewBag.FoodName = food.SchoolSupplieName;
            ViewBag.FridgeId = FridgeId;
            return View(new RequestSchoolSupplieBindingModel
            {
                SchoolSupplieId = FoodId.Value,
                WareHouseId = FridgeId.Value,
            });
        }
    }
}
