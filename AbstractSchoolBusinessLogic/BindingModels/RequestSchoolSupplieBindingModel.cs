using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.BindingModels
{
    public class RequestSchoolSupplieBindingModel
    {
        public int? Id { get; set; }
        public int RequestId { get; set; }
        public int SchoolSupplieId { get; set; }
        public int Count { get; set; }
    }
}
