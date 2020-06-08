using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.BindingModels
{
    public class WareHouseBindingModel
    {
        public int? Id { get; set; }
        public int SupplierId {get;set;}
        public string WareHouseName { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }
    }
}
