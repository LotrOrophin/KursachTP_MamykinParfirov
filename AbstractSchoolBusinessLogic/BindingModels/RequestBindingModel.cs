using AbstractSchoolBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.BindingModels
{
    public class RequestBindingModel
    {
        public int? Id { get; set; }
        public int? SupplierId { get; set; }
        public decimal Sum { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public List<RequestSchoolSupplieBindingModel> RequestScholSupllies { get; set; }
    }
}
