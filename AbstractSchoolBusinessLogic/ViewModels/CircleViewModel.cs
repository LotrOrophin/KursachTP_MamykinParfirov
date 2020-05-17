using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class CircleViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название кружка")]
        public string CircleName { get; set; }
        [DisplayName("Число участников")]
        public int StudentNumber { get; set; }
        [DisplayName("ФИО руководителя")]
        public string TeacherName { get; set; }
        [DisplayName("Специальность преподавателя")]
        public string Specialty { get; set; }
        [DisplayName("Возраст преподавателя")]
        public int Age { get; set; }
        public Dictionary<int, (string, int)> CircleStationery { get; set; }
    }

}
