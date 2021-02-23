using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.Enums;
using AbstractSchoolBusinessLogic.Interfaces;
using AbstractSchoolBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.BusinessLogics
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly IRequestLogic requestLogic;
        private readonly ICircleLogic circleLogic;

        public MainLogic(IOrderLogic orderLogic, IRequestLogic requestLogic, ICircleLogic circleLogic)
        {
            this.orderLogic = orderLogic;
            this.requestLogic = requestLogic;
            this.circleLogic = circleLogic;
        }

        public void CreateOrder(KursBindingModel order)
        {
            orderLogic.CreateOrUpdate(new KursBindingModel
            {
                CircleId = order.CircleId,
                Count = order.Count,
                CreationDate = DateTime.Now,
                KursStatus = KursStatus.Подготавливается
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new KursBindingModel { Id = model.OrderId })?[0];
            var request = requestLogic.Read(new RequestBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден такой курс");
            }

            if (order.KursStatus != KursStatus.Подготавливается)
            {
                throw new Exception("Курс еще не рассмотрен");
            }

            if (request.Status != RequestStatus.Готова)
            {
                throw new Exception("Поставка еще не произведена");
            }
            requestLogic.CreateOrUpdate(new RequestBindingModel
            {
                Status = RequestStatus.Обработана
            });

            orderLogic.CreateOrUpdate(new KursBindingModel
            {
                Id = order.Id,
                CircleId = order.CircleId,
                Count = order.Count,
                Sum = order.Sum,
                CreationDate = order.CreationDate,
                KursStatus = KursStatus.ВПроцессе
            });
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new KursBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден такой курс");
            }
            if (order.KursStatus != KursStatus.ВПроцессе)
            {
                throw new Exception("Курс еще не начался");
            }
            orderLogic.CreateOrUpdate(new KursBindingModel
            {
                Id = order.Id,
                CircleId = order.CircleId,
                Count = order.Count,
                Sum = order.Sum,
                CreationDate = order.CreationDate,
                CompletionDate = DateTime.Now,
                KursStatus = KursStatus.Завершен
            });
        }

        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new KursBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден курс");
            }
            if (order.KursStatus != KursStatus.Завершен)
            {
                throw new Exception("Курс еще не завершился");
            }
            orderLogic.CreateOrUpdate(new KursBindingModel
            {
                Id = order.Id,
                CircleId = order.CircleId,
                Count = order.Count,
                Sum = order.Sum,
                CreationDate = order.CreationDate,
                CompletionDate = order.CompletionDate,
                KursStatus = KursStatus.Оплачен
            });
        }
        public void CreateOrUpdateRequest(RequestBindingModel model)
        {
            requestLogic.CreateOrUpdate(new RequestBindingModel
            {
                Id = model.Id,
                SupplierId = model.SupplierId,
                Status = RequestStatus.Создана,
                SchoolSupllies = model.SchoolSupllies,
                CreationDate = DateTime.Now
            });
        }
        public List<ReportCircleSchoolSupplieViewModel> GetCircleSchoolSuppliesOrder()
        {
            var circles = circleLogic.Read(null);
            var list = new List<ReportCircleSchoolSupplieViewModel>();
            foreach (var circle in circles)
            {
                foreach (var pc in circle.CircleSchoolSupplies)
                {
                    var record = new ReportCircleSchoolSupplieViewModel
                    {
                        CircleName = circle.CircleName,
                        SchoolSupplieName = pc.Value.Item1,
                        Count = pc.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }
    }
}
