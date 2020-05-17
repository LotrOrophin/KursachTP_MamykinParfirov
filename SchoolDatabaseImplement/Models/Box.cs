using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolDatabaseImplement.Models
{
    public class Box
    {
        public int Id { get; set; }
        [Required]
        public string BoxName { get; set; }
        [Required]
        public int Capacity { get; set; }
        [ForeignKey("BoxId")]
        public virtual List<BoxJewerly> BoxJewerlies { get; set; }
        public Supplier Supplier { get; set; }
    }
}
