using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WoodStore.DAL.Interfaces;
using WoodStore.Domain.Entity;
using WoodStore.Domain.Enum;
using WoodStore.Domain.Response;
using WoodStore.Service.Interfaces;
using WoodStore.Domain.ViewModel.Orders;

namespace WoodStore.Service.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IBaseResponse<Order>> GetOrder(int orderId)
        {
            var baseResponse = new BaseResponse<Order>();
            try
            {
                var order = await _orderRepository.Get(orderId);
                if(order == null)
                {
                    baseResponse.Description = "Order not found!";
                    baseResponse.StatusCode = StatusCode.OrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = order;
                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<Order>()
                {
                    Description = $"[GetOrder] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Order>> GetById(int id)
        {
            var baseResponse = new BaseResponse<Order>();
            try
            {
                var order = await _orderRepository.GetById(id);
                if (order == null)
                {
                    baseResponse.Description = "Order not found!";
                    baseResponse.StatusCode = StatusCode.OrderNotFound;
                    return baseResponse;
                }

                baseResponse.Data = order;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Order>()
                {
                    Description = $"[GetOrder] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<OrderViewModel>> CreateOrder(OrderViewModel orderViewModel)
        {
            var baseResponse = new BaseResponse<OrderViewModel>();

            try {
                var order = new Order()
                {
                    OrderDate = orderViewModel.OrderDate,
                    OrderPrice = orderViewModel.OrderPrice,
                    ClientsComment = orderViewModel.ClientsComment,
                    СourierID = orderViewModel.СourierID,
                    PickerID = orderViewModel.PickerID,
                    ClientID = orderViewModel.ClientID,
                    SalesManagerID = orderViewModel.SalesManagerID
                };

                await _orderRepository.Create(order);
            }
            catch(Exception ex)
            {
                return new BaseResponse<OrderViewModel>()
                {
                    Description = $"[CreateOrder] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return baseResponse;
        }


        public async Task<IBaseResponse<bool>> DeleteOrder(int orderId)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var order = await _orderRepository.Get(orderId);
                if (order == null)
                {
                    baseResponse.Description = "Order not found!";
                    baseResponse.StatusCode = StatusCode.OrderNotFound;
                    return baseResponse;
                }

               await _orderRepository.Delete(order);
                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteOrder] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Order>>> GetAllOrders()
        {
            var baseResponse = new BaseResponse<IEnumerable<Order>>();
            try
            {
                var orders = await _orderRepository.Select();
                if (orders.Count == 0)
                {
                    baseResponse.Description = "Заказов нет!";
                    baseResponse.StatusCode = StatusCode.Ok;
                    return baseResponse;
                }

                baseResponse.Data = orders;
                baseResponse.StatusCode = StatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Order>>()
                {
                    Description = $"[GetAllOrders] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Order>> UpdateOrder(int orderId, OrderViewModel model)
        {
            var baseResponse = new BaseResponse<Order>();

            try
            {
                var order = await _orderRepository.GetById(orderId);
                if (order == null)
                {
                    baseResponse.Description = "Заказов нет!";
                    baseResponse.StatusCode = StatusCode.OrderNotFound;
                    return baseResponse;
                }

                order.OrderID = model.Id;
                order.ClientID = model.ClientID;
                order.ClientsComment = model.ClientsComment;
                order.OrderDate = model.OrderDate;
                order.OrderPrice = model.OrderPrice;
                order.PickerID = model.PickerID;
                order.SalesManagerID = model.SalesManagerID;
                order.СourierID = model.СourierID;

                await _orderRepository.Update(order);

                return baseResponse;
                
            }
            catch (Exception ex)
            {
                return new BaseResponse<Order>()
                {
                    Description = $"[UpdateOrder] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
