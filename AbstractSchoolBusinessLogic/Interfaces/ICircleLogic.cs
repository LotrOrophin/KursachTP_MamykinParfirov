using AbstractSchoolBusinessLogic.BindingModels;
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
    }
}
