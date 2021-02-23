using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.BindingModels
{
    public class SchoolSupplieBindingModel
    {
        public int? Id { get; set; }
        public string SchoolSupplieName { get; set; }
        public decimal Price { get; set; }
    }
}
