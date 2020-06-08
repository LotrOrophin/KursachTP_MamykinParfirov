using AbstractSchoolBusinessLogic.Enums;
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
        public RequestStatus Status { get; set; }
        [ForeignKey("RequestId")]
        public virtual List<RequestSchoolSupplie> RequestFoods { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
