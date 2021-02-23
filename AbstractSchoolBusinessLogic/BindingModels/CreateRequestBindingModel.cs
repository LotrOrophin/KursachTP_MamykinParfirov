using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.BindingModels
{
    public class CreateRequestBindingModel
    {
        public int? SupplierId { get; set; }
        public Dictionary<int, (string, int)> SchoolSupplies { get; set; }
    }
}
