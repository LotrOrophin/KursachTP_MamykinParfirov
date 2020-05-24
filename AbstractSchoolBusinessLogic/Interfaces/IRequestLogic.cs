using AbstractSchoolBusinessLogic.BindingModels;
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
    }
}
