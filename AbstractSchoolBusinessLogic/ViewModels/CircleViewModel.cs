using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class CircleViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название блюда")]
        public string CircleName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> SchoolSupplieCircles { get; set; }
    }

}
