using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolDatabaseImplement.Models
{
    public class Jewerly
    {
        public int Id { get; set; }
        [Required]
        public string JewerlyName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("JewerlyId")]
        public virtual List<ProductJewerly> ProductJewerlies { get; set; }
        [ForeignKey("ProductId")]
        public virtual List<RequestProduct> RequestProducts { get; set; }
    }
}
