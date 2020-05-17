using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.BindingModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class CircleBindingModel
    {
        public int? Id { get; set; }
        public string CircleName { get; set; }
        public int StudentNumber { get; set; }
        public string TeacherName { get; set; }
        public string Specialty { get; set; }
        public int Age { get; set; }
        public Dictionary<int, (string, int)> CircleStationery { get; set; }
    }
}
