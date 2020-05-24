using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    public class RequestSchoolSupplieViewModel
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int SchoolSupplieId { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
