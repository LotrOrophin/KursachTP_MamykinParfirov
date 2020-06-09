using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolDatabaseImplement.Models;

namespace SchoolWebSupplier.Controllers
{
    public class WareHouseController : Controller
    {
        private readonly IWareHouseLogic wareHouseLogic;
        private readonly ISchoolSupplieLogic schoolSupplieLogic;

        public WareHouseController(IWareHouseLogic wareHouseLogic, ISchoolSupplieLogic schoolSupplieLogic)
        {
            this.wareHouseLogic = wareHouseLogic;
            this.schoolSupplieLogic = schoolSupplieLogic;
        }

        public IActionResult ListWareHouses()
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            var fridge = wareHouseLogic.Read(new WareHouseBindingModel
            {
                SupplierId = Program.Supplier.Id
            });
            return View(fridge);
        }

        public IActionResult Details(int? id)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.FridgeId = id;
            var schoolSupplies = wareHouseLogic.Read(new WareHouseBindingModel
            {
                Id = id
            })?[0].SchoolSupplies;
            return View(schoolSupplies);
        }

        public IActionResult CreateWareHouse()
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateWareHouse([Bind("WareHouseName,Size,Type")] WareHouse wareHouse)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    wareHouseLogic.CreateOrUpdate(new WareHouseBindingModel
                    {
                        WareHouseName = wareHouse.WareHouseName,
                        Size = wareHouse.Size,
                        Type = wareHouse.Type,
                        SupplierId = Program.Supplier.Id
                    });
                    return RedirectToAction(nameof(ListWareHouses));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(wareHouse);
        }

        public IActionResult ChangeWareHouse(int? id)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            if (id == null)
            {
                return NotFound();
            }
            var wareHouse = wareHouseLogic.Read(new WareHouseBindingModel
            {
                Id = id
            })?[0];
            if (wareHouse == null)
            {
                return NotFound();
            }
            return View(new WareHouse
            {
                Id = id.Value,
                WareHouseName = wareHouse.WareHouseName,
                Size = wareHouse.Size,
                Type = wareHouse.Type
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeWareHouse(int id, [Bind("Id,WareHouseName,Size,Type")] WareHouse wareHouse)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            if (id != wareHouse.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    wareHouseLogic.CreateOrUpdate(new WareHouseBindingModel
                    {
                        Id = id,
                        WareHouseName = wareHouse.WareHouseName,
                        Size = wareHouse.Size,
                        Type = wareHouse.Type,
                        SupplierId = Program.Supplier.Id
                    });
                }
                catch (Exception exception)
                {
                    if (!WareHouseExists(wareHouse.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", exception.Message);
                        return View(wareHouse);
                    }
                }
                return RedirectToAction(nameof(ListWareHouses));
            }
            return View(wareHouse);
        }

        public IActionResult DeleteWareHouse(int? id)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            if (id == null)
            {
                return NotFound();
            }
            var fridge = wareHouseLogic.Read(new WareHouseBindingModel
            {
                Id = id
            })?[0];
            if (fridge == null)
            {
                return NotFound();
            }
            return View(new WareHouse
            {
                Id = id.Value,
                WareHouseName = fridge.WareHouseName,
                Size = fridge.Size,
                Type = fridge.Type
            });
        }

        [HttpPost, ActionName("DeleteWareHouse")]
        [ValidateAntiForgeryToken]
        public IActionResult Completion(int id)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            wareHouseLogic.Delete(new WareHouseBindingModel
            {
                Id = id
            });
            return RedirectToAction(nameof(ListWareHouses));
        }

        private bool WareHouseExists(int id)
        {
            return wareHouseLogic.Read(new WareHouseBindingModel
            {
                Id = id
            }).Count == 1;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSchoolSupplie([Bind("WareHouseId, SchoolSupplieId, Count")] RequestSchoolSupplieBindingModel model)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    wareHouseLogic.AddSchoolSupplie(model);
                }
                catch (Exception exception)
                {
                    TempData["ErrorLackInWareHouse"] = exception.Message;
                    return RedirectToAction("AddSchoolSupplie", "SchoolSupplie", new
                    {
                        schoolSupplieId = model.SchoolSupplieId,
                        wareHouseId = model.WareHouseId
                    });
                }
            }
            return RedirectToAction("Details", new { id = model.WareHouseId });
        }

        public IActionResult ReserveFoods(int wareHouseId, int schoolSupplieId, int count, int requestId)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            try
            {
                wareHouseLogic.ReserveSchoolSupplies(new RequestSchoolSupplieBindingModel
                {
                    WareHouseId = wareHouseId,
                    SchoolSupplieId = schoolSupplieId,
                    Count = count
                });
            }
            catch (Exception ex)
            {
                TempData["ErrorSchoolSupplieReserve"] = ex.Message;
                return RedirectToAction("RequestView", "Request", new { id = requestId });
            }
            return RedirectToAction("Reserve", "Request", new
            {
                RequestId = requestId,
                SchoolSupplieId = schoolSupplieId
            });
        }
    }
}
