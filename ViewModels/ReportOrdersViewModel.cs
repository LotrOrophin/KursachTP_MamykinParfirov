using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using AbstractSchoolBusinessLogic.Enums;

namespace AbstractSchoolBusinessLogic.ViewModels
{
   public class ReportOrdersViewModel
    {
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        [DisplayName("Канцтовар")]
        public string StationeryName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }

        [DisplayName("Сумма")]
        public decimal? Sum { get; set; }

        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }

    }
}
