using AbstractSchoolBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolDatabaseImplement.Models
{
    public class Kurs
    {
        public int Id { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        public DateTime? CompletionDate { get; set; }
        [Required]
        public KursStatus KursStatus { get; set; }
        public int CircleId { get; set; }
        public Circle Circle { get; set; }
    }
}
