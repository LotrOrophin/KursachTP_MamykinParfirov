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
        void SaveJson(string folderName);
        void SaveXml(string folderName);
    }
}
