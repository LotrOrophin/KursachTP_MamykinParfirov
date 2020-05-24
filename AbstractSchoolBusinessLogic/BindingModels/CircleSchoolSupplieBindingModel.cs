using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.BindingModels
{
    public class CircleSchoolSupplieBindingModel
    {
        public int? Id { get; set; }
        public int SchoolSupplieId { get; set; }
        public int CircleId { get; set; }
        public int Count { get; set; }
    }
}
