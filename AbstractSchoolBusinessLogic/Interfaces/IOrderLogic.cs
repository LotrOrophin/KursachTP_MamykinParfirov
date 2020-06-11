using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.Interfaces
{
    public interface IOrderLogic
    {
        List<KursViewModel> Read(KursBindingModel model);
        void CreateOrUpdate(KursBindingModel model);
        void Delete(KursBindingModel model);
        void SaveJsonOrder(string folderName);
        void SaveXmlOrder(string folderName);
    }
}
