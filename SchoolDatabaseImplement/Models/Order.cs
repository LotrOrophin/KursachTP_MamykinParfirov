﻿using AbstractSchoolBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolDatabaseImplement.Models
{
    public class Order
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
        public OrderStatus Status { get; set; }
        public int DishId { get; set; }
        public Product Product { get; set; }
    }
}
