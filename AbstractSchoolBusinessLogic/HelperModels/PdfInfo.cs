﻿using AbstractSchoolBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace AbstractSchoolBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }
        public List<ReportSchoolSupplieViewModel> SchoolSupplies { get; set; }
    }
}
