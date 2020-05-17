using AbstractSchoolBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    //
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        public int Id { get; set; }     
        [DataMember]
        public int PurveyorId { get; set; }
        //[DataMember]
        //public int ProductId { get; set; } стоит ли делать тут упоминание о кружках на которые идут канцтовары???
        [DataMember]
        [DisplayName("Клиент")]
        public string PurveyorFIO { get; set; }
        public int StationeryId { get; set; }
        [DisplayName("Изделие")]
        public string StationeryName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }

        [DisplayName("Сумма")]
        public decimal Sum { get; set; }

        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }

        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }

    }
}
