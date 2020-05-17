using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolDatabaseImplement.Models
{
    public class BoxJewerly
    {
        public int Id { get; set; }
        public int BoxId { get; set; }
        public int JewerlyId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int IsReserved { get; set; }
        public Box Box { get; set; }
        public Jewerly Jewerly { get; set; }
    }
}
