using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.BindingModels
{
    public class RequestSchoolSupplieBindingModel
    {
        public int WareHouseId { get; set; }
        public int SchoolSupplieId { get; set; }
        public int Count { get; set; }
        public int PricePerHour { get; set; }
    }
}
