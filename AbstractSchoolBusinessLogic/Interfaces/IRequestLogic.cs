using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.Interfaces
{
    public interface IRequestLogic
    {
        List<RequestViewModel> Read(RequestBindingModel model);
        void CreateOrUpdate(RequestBindingModel model);
        void Delete(RequestBindingModel model);
        void Reserve(ReserveSchoolSuppliesBindingModel model);
        void SaveJsonRequest(string folderName);
        void SaveJsonRequestSchoolSupplie(string folderName);
        void SaveXmlRequest(string folderName);
        void SaveXmlRequestSchoolSupplie(string folderName);
    }
}
