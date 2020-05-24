using AbstractSchoolBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<CircleViewModel> Circles { get; set; }
        public List<WareHouseViewModel> Warehouses { get; set; }
    }
}
