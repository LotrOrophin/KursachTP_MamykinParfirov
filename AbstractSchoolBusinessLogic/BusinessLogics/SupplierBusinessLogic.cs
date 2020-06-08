using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.Enums;
using AbstractSchoolBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.BusinessLogics
{
    public class SupplierBusinessLogic
    {
        private readonly IRequestLogic requestLogic;
        public SupplierBusinessLogic(IRequestLogic requestLogic)
        {
            this.requestLogic = requestLogic;
        }

        public void AcceptRequest(ChangeRequestStatusBindingModel model)
        {
            var request = requestLogic.Read(new RequestBindingModel
            {
                Id = model.RequestId
            })?[0];
            if (request == null)
            {
                throw new Exception("Заявка не найдена");
            }
            if (request.Status != RequestStatus.Создана)
            {
                throw new Exception("Заявка не в статусе \"Создана\"");
            }
            requestLogic.CreateOrUpdate(new RequestBindingModel
            {
                Id = request.Id,
                SupplierId = request.SupplierId,
                Status = RequestStatus.Выполняется,
                RequestSchoolSupllies = request.SchoolSupplies
            });
        }

        public void CompleteRequest(ChangeRequestStatusBindingModel model)
        {
            var request = requestLogic.Read(new RequestBindingModel
            {
                Id = model.RequestId
            })?[0];
            if (request == null)
            {
                throw new Exception("Заявка не найдена");
            }
            if (request.Status != RequestStatus.Выполняется)
            {
                throw new Exception("Заявка не в статусе \"Выполняется\"");
            }
            requestLogic.CreateOrUpdate(new RequestBindingModel
            {
                Id = request.Id,
                SupplierId = request.SupplierId,
                Status = RequestStatus.Готова,
                RequestSchoolSupllies = request.SchoolSupplies
            });
        }

        public void ReserveFoods(ReserveSchoolSuppliesBindingModel model)
        {
            var request = requestLogic.Read(new RequestBindingModel
            {
                Id = model.RequestId
            })?[0];
            if (request == null)
            {
                throw new Exception("Заявка не найдена");
            }
            if (request.Status != RequestStatus.Выполняется)
            {
                throw new Exception("Заявка не в статусе \"Выполняется\"");
            }
            requestLogic.Reserve(model);
        }
    }
}
