using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    public class SchoolSupplieCircleViewModel
    {
        public int Id { get; set; }
        public int SchoolSupplieId { get; set; }
        public int CircleId { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
