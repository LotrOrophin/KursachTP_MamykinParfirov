using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using AbstractSchoolBusinessLogic.Enums;


namespace AbstractSchoolBusinessLogic.BindingModels
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int CircleId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }

}
