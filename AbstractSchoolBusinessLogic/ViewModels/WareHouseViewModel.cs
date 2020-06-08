using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    public class WareHouseViewModel
    {
        [DisplayName("Номер склада")]
        public int Id { get; set; }
        [DisplayName("Название склада")]
        public string WareHouseName { get; set; }
        [DisplayName("Вместимость")]
        public int Capacity { get; set; }
        [DisplayName("Тип склада")]
        public string Type { get; set; }
        public Dictionary<int, (string, int, int)> SchoolSupplies { get; set; }
    }
}
