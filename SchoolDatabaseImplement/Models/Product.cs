using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolDatabaseImplement.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("ProductId")]
        public virtual List<Order> Orders { get; set; }
        [ForeignKey("DishId")]
        public virtual List<ProductJewerly> ProductJewerlies { get; set; }
    }
}
