using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.BindingModels
{
    public class WareHouseBingingModel
    {
        public int? Id { get; set; }
        public string WareHouseName { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
    }
}
