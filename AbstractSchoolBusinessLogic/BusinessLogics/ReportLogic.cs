using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.BusinessLogic;
using AbstractSchoolBusinessLogic.HelperModels;
using AbstractSchoolBusinessLogic.Interfaces;
using AbstractSchoolBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSchoolBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly ICircleLogic circleLogic;
        private readonly IOrderLogic orderLogic;
        private readonly IWareHouseLogic warehouseLogic;

        public ReportLogic(ICircleLogic circleLogic, IOrderLogic orderLogic, IWareHouseLogic warehouseLogic)
        {
            this.circleLogic = circleLogic;
            this.orderLogic = orderLogic;
            this.warehouseLogic = warehouseLogic;
        }

        public List<ReportCircleSchoolSupplieViewModel> GetCircleSchoolSupplie()
        {
            var dishes = circleLogic.Read(null);
            var list = new List<ReportCircleSchoolSupplieViewModel>();
            foreach (var dish in dishes)
            {
                foreach (var pc in dish.SchoolSupplieCircles)
                {
                    var record = new ReportCircleSchoolSupplieViewModel
                    {
                        CircleName = dish.CircleName,
                        SchoolSupplieName = pc.Value.Item1,
                        Count = pc.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }

        public List<ReportWareHouseSchoolSupplieViewModel> GetWarehouseSchoolSupplie()
        {
            var fridges = warehouseLogic.Read(null);
            var list = new List<ReportWareHouseSchoolSupplieViewModel>();
            foreach (var fridge in fridges)
            {
                foreach (var ff in fridge.WareHouseSchoolSupplies)
                {
                    var record = new ReportWareHouseSchoolSupplieViewModel
                    {
                        WareHouseName = fridge.WareHouseName,
                        SchoolSupplieName = ff.Value.Item1,
                        Count = ff.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }

        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic
            .Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .GroupBy(rec => rec.CreationDate.Date)
            .OrderBy(recG => recG.Key)
            .ToList();
            return list;
        }

        public void SaveCirclesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список кружков",
                Circles = circleLogic.Read(null),
                Warehouses = null
            });
        }

        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model),
                Warehouses = null
            });
        }

        public void SaveCirclesSchoolSuppliesToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список кружков по канцелярии",
                SchoolSuppliesCircles = GetCircleSchoolSupplie(),
                WarehouseSchoolSupplies = null
            });
        }

        public void SaveFridgesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                Circles = null,
                Warehouses = warehouseLogic.Read(null)
            });
        }

        public void SaveFridgeFoodsToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список канцелярии на складе",
                Orders = null,
                Warehouses = warehouseLogic.Read(null)
            });
        }

        public void SaveSchoolSuppliesToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список канцелярии",
                SchoolSuppliesCircles = null,
                WarehouseSchoolSupplies = GetWarehouseSchoolSupplie()
            });
        }
    }
}
