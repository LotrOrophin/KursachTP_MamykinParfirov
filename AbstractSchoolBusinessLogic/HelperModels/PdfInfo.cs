﻿using AbstractSchoolBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace AbstractSchoolBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportCircleSchoolSupplieViewModel> SchoolSuppliesCircles { get; set; }
        public List<ReportWareHouseSchoolSupplieViewModel> WarehouseSchoolSupplies { get; set; }
    }
}
