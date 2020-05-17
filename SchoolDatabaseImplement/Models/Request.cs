﻿using AbstractSchoolBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolDatabaseImplement.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        public DateTime? DateImplement { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        public Supplier Supplier { get; set; }
    }
}
