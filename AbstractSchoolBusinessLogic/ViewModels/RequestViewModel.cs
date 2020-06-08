using AbstractSchoolBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractSchoolBusinessLogic.ViewModels
{
    public class RequestViewModel
    {
        [DisplayName("Номер заявки")]
        public int Id { get; set; }
        public int SupplierId { get; set; }
        [DisplayName("ФИО")]
        public string SupplierFIO { get; set; }
        [DisplayName("Статус")]
        public RequestStatus Status { get; set; }
        public Dictionary<int, (string, int, bool)> SchoolSupplies { get; set; }
    }
}
