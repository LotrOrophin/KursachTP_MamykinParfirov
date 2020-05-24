using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.Interfaces
{
    public interface IWareHouseLogic
    {
        List<WareHouseViewModel> Read(WareHouseBingingModel model);
        void CreateOrUpdate(WareHouseBingingModel model);
        void Delete(WareHouseBingingModel model);
        void AddSchoolSupplie(WareHouseSchoolSupplieBindingModel model);
        void RemoveFromWareHouse(OrderViewModel model);
    }
}
