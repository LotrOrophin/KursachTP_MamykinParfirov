using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using AbstractSchoolBusinessLogic.Enums;


namespace AbstractSchoolBusinessLogic.BindingModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    /// 
    [DataContract]
    public class OrderBindingModel
    {
        [DataMember]
        public int PurveyorId { get; set; }
        [DataMember]
        public int StationeryId { get; set; }
        [DataMember]
        public int? Id { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }

}
