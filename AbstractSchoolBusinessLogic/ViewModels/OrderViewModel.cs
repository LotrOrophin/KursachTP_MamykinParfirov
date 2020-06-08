using AbstractSchoolBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        [DisplayName("Дата создания")]
        public DateTime CreationDate { get; set; }
        [DisplayName("Дата завершения")]
        public DateTime? CompletionDate { get; set; }
        [DisplayName("Статус")]
        public OrderStatus OrderStatus { get; set; }
        public int CircleId { get; set; }
        [DisplayName("Название кружка")]
        public string CircleName { get; set; }
    }
}
