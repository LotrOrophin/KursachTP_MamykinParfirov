using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    public class WareHouseSchoolSupplieViewModel
    {
        public int Id { get; set; }
        public int WareHouseId { get; set; }
        public int SchoolSupplieId { get; set; }
        [DisplayName("Название канцелярии")]
        public string SchoolSupplieName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DisplayName("Резервация")]
        public int IsReserved { get; set; }
    }
}
