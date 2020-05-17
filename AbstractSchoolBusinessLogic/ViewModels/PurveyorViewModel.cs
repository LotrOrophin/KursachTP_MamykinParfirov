using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    [DataContract]
    class PurveyorViewModel
    {
        [DataMember]
        public int PurveyorId { get; set; }
        [DataMember]
        [DisplayName("ФИО Поставщика")]
        public string PurveyorFullName { get; set; }
        [DataMember]
        [DisplayName("Пароль ")]
        public int Password { get; set; }
        [DataMember]
        [DisplayName("ФИО Логин/Почта")]
        public string Login { get; set; }
    }
}
