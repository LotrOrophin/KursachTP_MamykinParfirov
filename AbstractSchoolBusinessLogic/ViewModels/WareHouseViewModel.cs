using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    public class WareHouseViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название скалад")]
        public string WareHouseName { get; set; }
        [DisplayName("Вместимость")]
        public int Capacity { get; set; }
        [DisplayName("Тип склада")]
        public string Type { get; set; }
        public Dictionary<int, (string, int)> WareHouseSchoolSupplies { get; set; }
    }
}
