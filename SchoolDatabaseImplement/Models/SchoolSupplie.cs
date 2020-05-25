using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolDatabaseImplement.Models
{
    public class SchoolSupplie
    {
        public int Id { get; set; }
        [Required]
        public string SchoolSupplieName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("SchoolSupplieId")]
        public virtual List<CircleSchoolSupplie> CircleSchoolSupplies { get; set; }
        [ForeignKey("SchoolSupplieId")]
        public virtual List<RequestSchoolSupplie> RequestSchoolSupplie { get; set; }
    }
}
