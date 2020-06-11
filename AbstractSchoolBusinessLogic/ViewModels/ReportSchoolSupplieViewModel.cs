using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    public class ReportSchoolSupplieViewModel
    {
        public string SupplierFIO { get; set; }
        public string SchoolSupplieName { get; set; }
        public int Count { get; set; }
        public string Status { get; set; }
        public int RequestId { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public decimal PricePerHour { get; set; }
        public decimal Sum { get; set; }
    }
}
