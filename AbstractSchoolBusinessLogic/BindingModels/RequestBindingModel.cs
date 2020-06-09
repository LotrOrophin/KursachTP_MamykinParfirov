using AbstractSchoolBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.BindingModels
{
    public class RequestBindingModel
    {
        public int? Id { get; set; }
        public int SupplierId { get; set; }
        public decimal Sum { get; set; }
        public RequestStatus Status { get; set; }
        public Dictionary<int, (string, int, bool)> SchoolSupllies { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}
