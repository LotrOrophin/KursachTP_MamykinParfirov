using AbstractSchoolBusinessLogic.BindingModels;
using AbstractSchoolBusinessLogic.Enums;
using AbstractSchoolBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSchoolBusinessLogic.BusinessLogics
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly IWareHouseLogic wareHouseLogic;

        public MainLogic(IOrderLogic orderLogic, IWareHouseLogic wareHouseLogic)
        {
            this.orderLogic = orderLogic;
            this.wareHouseLogic = wareHouseLogic;
        }

        public void CreateOrder(CircleSchoolSupplieBindingModel model)
        {
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                CircleId = model.CircleId,
                Count = model.Count,
                CreationDate = DateTime.Now,
                OrderStatus = OrderStatus.Принят
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];

            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }

            if (order.OrderStatus != OrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }

            wareHouseLogic.RemoveFromWareHouse(order);

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

        public void ReplanishFridge(WareHouseSchoolSupplieBindingModel model)
        {
            wareHouseLogic.AddSchoolSupplie(model);
        }
    }
}
