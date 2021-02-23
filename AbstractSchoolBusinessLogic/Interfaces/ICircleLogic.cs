using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.Interfaces
{
    public interface ICircleLogic
    {
        List<CircleViewModel> Read(CircleBindingModel model);
        void CreateOrUpdate(CircleBindingModel model);
        void Delete(CircleBindingModel model);
        void SaveJsonCircle(string folderName);
        void SaveXmlCircle(string folderName);
        void SaveJsonCircleSchoolSupplie(string folderName);
        void SaveXmlCircleSchoolSupplie(string folderName);
    }
}
