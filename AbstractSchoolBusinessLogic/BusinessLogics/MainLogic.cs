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

        public void CreateOrder(OrderBindingModel order)
        {
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                CircleId = order.CircleId,
                Count = order.Count,
                CreationDate = DateTime.Now,
                OrderStatus = OrderStatus.Принят
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            var request = requestLogic.Read(new RequestBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }

            if (order.OrderStatus != OrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }

            if (request.Status != RequestStatus.Готова)
            {
                throw new Exception("Продукты ещё не доставлены");
            }
            requestLogic.CreateOrUpdate(new RequestBindingModel
            {
                Status = RequestStatus.Обработана
            });

            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                CircleId = order.CircleId,
                Count = order.Count,
                Sum = order.Sum,
                CreationDate = order.CreationDate,
                OrderStatus = OrderStatus.Выполняется
            });
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.OrderStatus != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                CircleId = order.CircleId,
                Count = order.Count,
                Sum = order.Sum,
                CreationDate = order.CreationDate,
                CompletionDate = DateTime.Now,
                OrderStatus = OrderStatus.Готов
            });
        }

        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.OrderStatus != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                CircleId = order.CircleId,
                Count = order.Count,
                Sum = order.Sum,
                CreationDate = order.CreationDate,
                CompletionDate = order.CompletionDate,
                OrderStatus = OrderStatus.Оплачен
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
