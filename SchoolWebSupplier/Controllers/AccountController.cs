using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolWebSupplier.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRequestLogic requestLogic;
        public AccountController(IRequestLogic requestLogic)
        {
            this.requestLogic = requestLogic;
        }
        public IActionResult Main()
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            var requests = requestLogic.Read(new RequestBindingModel
            {
                SupplierID = Program.Supplier.ID
            });
            return View(requests);
        }
        public IActionResult Main()
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            var requests = requestLogic.Read(new RequestBindingModel
            {
                SupplierID = Program.Supplier.ID
            });
            return View(requests);
        }
        public IActionResult RequestView(int id)
        {
            if (Program.Supplier == null)
            {
                return new UnauthorizedResult();
            }
            ViewBag.RequestID = id;
            var components = requestLogic.Read(new RequestBindingModel
            {
                SupplierID = Program.Supplier.ID
            })?[0].Components;
            return View(components);
        }
    }
}
