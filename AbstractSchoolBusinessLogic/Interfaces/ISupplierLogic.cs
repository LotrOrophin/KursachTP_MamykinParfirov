using AbstractSchoolBusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.Interfaces
{
    public interface ISupplierLogic
    {
        List<SupplierViewModel> Read(SupplierBindingModel model);
        void CreateOrUpdate(SupplierBindingModel model);
        void Delete(SupplierBindingModel model);
    }
}
