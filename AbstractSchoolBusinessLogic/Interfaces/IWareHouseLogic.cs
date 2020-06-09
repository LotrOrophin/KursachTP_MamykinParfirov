using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.Interfaces
{
    public interface IWareHouseLogic
    {
        List<WareHouseViewModel> Read(WareHouseBindingModel model);
        void CreateOrUpdate(WareHouseBindingModel model);
        void Delete(WareHouseBindingModel model);
        void AddSchoolSupplie(RequestSchoolSupplieBindingModel model);
        void ReserveSchoolSupplies(RequestSchoolSupplieBindingModel model);
        List<WareHouseAvailableViewModel> GetWareHouseAvailable(RequestSchoolSupplieBindingModel model);
        void SaveJsonWareHouse(string folderName);
        void SaveJsonWareHouseSchoolSupplie(string folderName);
        void SaveXmlWareHouse(string filderName);
        void SaveXmlWareHouseSchoolSupplie(string filderName);
    }
}
