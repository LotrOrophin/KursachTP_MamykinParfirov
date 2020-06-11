using AbstractSchoolBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    public class KursViewModel
    {
        public int Id { get; set; }
        public int CircleId { get; set; }
        [DisplayName("Название кружка")]
        public string CircleName { get; set; }
        [DisplayName("Дата начала")]
        public DateTime CreationDate { get; set; }
        [DisplayName("Дата завершения")]
        public DateTime? CompletionDate { get; set; }
        [DisplayName("Статус")]
        public KursStatus KursStatus { get; set; }
        [DisplayName("Количество занятий в курсе")]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
    }
}
