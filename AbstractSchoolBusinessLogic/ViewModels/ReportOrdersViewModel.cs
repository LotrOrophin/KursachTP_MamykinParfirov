using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using AbstractSchoolBusinessLogic.Enums;

namespace AbstractSchoolBusinessLogic.ViewModels
{
   public class ReportOrdersViewModel
    {
        public DateTime CreationDate { get; set; }
        public string CircleName { get; set; }
        public int Count { get; set; }
        public decimal Amount { get; set; }
        public OrderStatus Status { get; set; }
    }
}
