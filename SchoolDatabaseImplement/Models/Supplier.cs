using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolDatabaseImplement.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public int BoxId { get; set; }
        [Required]
        public string SupplierFIO { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Password { get; set; }
        public Box Box { get; set; }
        [ForeignKey("SupplierId")]
        public virtual List<Request> Requests { get; set; }
    }
}
