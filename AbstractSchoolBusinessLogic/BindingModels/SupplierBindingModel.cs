using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.BindingModels
{
    public class SupplierBindingModel
    {
        public int? Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SupplierFIO { get; set; }
    }
}
