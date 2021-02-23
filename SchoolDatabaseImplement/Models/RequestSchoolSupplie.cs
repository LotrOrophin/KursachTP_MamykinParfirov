using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolDatabaseImplement.Models
{
    public class RequestSchoolSupplie
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int SchoolSupplieId { get; set; }
        [Required]
        public bool Inres { get; set; }
        [Required]
        public int Count { get; set; }
        public SchoolSupplie SchoolSupplie { get; set; }
        public Request Request { get; set; }
    }
}
