using AbstractSchoolBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSchoolBusinessLogic.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportOrdersViewModel> Orders { get; set; }
        public List<WareHouseViewModel> Warehouses { get; set; }
        public int RequestId { get; set; }
        public string SupplierFIO { get; set; }
        public DateTime DateComplete { get; set; }
        public Dictionary<int, (string, int, bool)> SchoolSupplies { get; set; }
        public List<ReportCircleSchoolSupplieViewModel> CircleSchoolSupplies { get; set; }
    }
}
