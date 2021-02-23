using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolDatabaseImplement.Models
{
    public class WareHouseSchoolSupplie
    {
        public int Id { get; set; }
        public int WareHouseId { get; set; }
        public int SchoolSupplieId { get; set; }
        [Required]
        public int Free { get; set; }
        [Required]
        public int IsReserved { get; set; }
        public WareHouse WareHouse { get; set; }
        public SchoolSupplie SchoolSupplie { get; set; }
    }
}
