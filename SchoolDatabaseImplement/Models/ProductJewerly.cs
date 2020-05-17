using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolDatabaseImplement.Models
{
    public class ProductJewerly
    {
        public int Id { get; set; }
        [Required]
        public int Count { get; set; }
        public int ProductId { get; set; }
        public int JewerlyId { get; set; }
        public Product Product { get; set; }
        public Jewerly Jewerly { get; set; }
    }
}
