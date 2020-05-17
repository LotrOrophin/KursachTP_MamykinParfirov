using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class StationeryViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        public string StationeryName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DisplayName("Место на складе")]
        public int WarehousePlace { get; set; }
        [DisplayName("Место в школьном хранилище")]
        public int SchoolWarehousePlace { get; set; }
    }
}
