using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    public class WareHouseAvailableViewModel
    {
        [DisplayName("Склад")]
        public string WareHouseName { get; set; }
        public int WareHouseId { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
