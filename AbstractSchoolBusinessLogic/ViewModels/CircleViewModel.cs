using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    [DataContract]
    public class CircleViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Название кружка")]
        public string CircleName { get; set; }
        [DataMember]
        [DisplayName("Цена")]
        public decimal PricePerHour { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> CircleSchoolSupplies { get; set; }
    }
}
