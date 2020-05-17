using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.BindingModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class StationeryBindingModel
    {
        public int? Id { get; set; }
        public string StationeryName { get; set; }
        public decimal Price { get; set; }
        
    }
}
