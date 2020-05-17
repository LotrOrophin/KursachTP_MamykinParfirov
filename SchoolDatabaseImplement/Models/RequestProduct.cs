using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolDatabaseImplement.Models
{
    public class RequestProduct
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int ProductId { get; set; }
        [Required]
        public int Count { get; set; }
        public Product Product { get; set; }
        public Request Request { get; set; }
    }
}
