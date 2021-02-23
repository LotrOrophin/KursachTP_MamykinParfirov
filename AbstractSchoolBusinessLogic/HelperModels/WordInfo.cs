using AbstractSchoolBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<CircleViewModel> Circles { get; set; }
        public List<WareHouseViewModel> Warehouses { get; set; }
        public int RequestId { get; set; }
        public string SupplierFIO { get; set; }
        public Dictionary<int, (string, int, bool)> RequestSchoolSupplies { get; set; }
        public List<ReportCircleSchoolSupplieViewModel> CircleSchoolSupplies { get; set; }
        public List<ReportOrdersViewModel> Orders { get; set; }
    }
}
