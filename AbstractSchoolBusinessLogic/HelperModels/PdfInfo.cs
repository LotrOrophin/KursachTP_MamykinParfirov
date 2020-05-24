﻿using AbstractSchoolBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace AbstractSchoolBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportSchoolSupplieViewModel> SchoolSupplies { get; set; }
        public List<ReportStationeryViewModel> Stationery { get; set; }
    }
}
