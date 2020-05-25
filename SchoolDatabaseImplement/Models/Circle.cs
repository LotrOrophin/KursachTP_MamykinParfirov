using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolDatabaseImplement.Models
{
    public class Circle
    {
        public int Id { get; set; }
        [Required]
        public string CircleName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("CircleId")]
        public virtual List<Order> Orders { get; set; }
        [ForeignKey("CircleId")]
        public virtual List<CircleSchoolSupplie> CircleSchoolSupplies { get; set; }
    }
}
