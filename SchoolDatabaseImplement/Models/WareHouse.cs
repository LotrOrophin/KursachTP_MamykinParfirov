using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolDatabaseImplement.Models
{
    public class WareHouse
    {
        public int Id { get; set; }
        [Required]
        public string WareHouseName { get; set; }
        [Required]
        public int Size { get; set; }
        public string Type { get; set; }
        [ForeignKey("WareHouseId")]
        public virtual List<WareHouseSchoolSupplie> WareHouseSchoolSupplies { get; set; }
        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
        }
}
