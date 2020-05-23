﻿using System;
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
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> SchoolSupplieCircles { get; set; }
    }
}
