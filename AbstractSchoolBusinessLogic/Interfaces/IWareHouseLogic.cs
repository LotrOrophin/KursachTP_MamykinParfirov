using AbstractSchoolBusinessLogic.BindingModels;
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
        void AddFood(WareHouseBingingModel model);
        void RemoveFromFridge(OrderViewModel model);
    }
}
