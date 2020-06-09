using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.Interfaces
{
    public interface ISchoolSupplieLogic
    {
        List<SchoolSupplieViewModel> Read(SchoolSupplieBindingModel model);
        void CreateOrUpdate(SchoolSupplieBindingModel model);
        void Delete(SchoolSupplieBindingModel model);
        void SaveJsonSchoolSupplie(string folderName);
        void SaveXmlSchoolSupplie(string folderName);
    }
}
