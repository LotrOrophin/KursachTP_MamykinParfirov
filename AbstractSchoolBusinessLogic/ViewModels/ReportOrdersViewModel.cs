using AbstractSchoolBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime CreationDate { get; set; }
        public string CircleName { get; set; }
        public int Count { get; set; }
        public decimal Amount { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
