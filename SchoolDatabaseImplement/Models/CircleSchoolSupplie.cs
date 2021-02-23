using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolDatabaseImplement.Models
{
    public class CircleSchoolSupplie
    {
        public int Id { get; set; }
        [Required]
        public int Count { get; set; }
        public int SchoolSupplieId { get; set; }
        public int CircleId { get; set; }
        public SchoolSupplie SchoolSupplie { get; set; }
        public Circle Circle { get; set; }
    }
}
