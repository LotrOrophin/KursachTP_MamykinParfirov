using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    public class SchoolSupplieViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название продукта")]
        public string SchoolSupplieName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
    }
}
