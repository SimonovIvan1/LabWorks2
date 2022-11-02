using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WoodStore.Domain.Entity;
using WoodStore.Domain.Response;
using WoodStore.Domain.ViewModel.Orders;

namespace WoodStore.Service.Interfaces
{
    public interface IOrderService
    {
        Task<IBaseResponse<IEnumerable<Order>>> GetAllOrders();

        Task<IBaseResponse<OrderViewModel>> CreateOrder(OrderViewModel orderViewModel);

        Task<IBaseResponse<Order>> GetById(int id);

        Task<IBaseResponse<bool>> DeleteOrder(int orderId);

        Task<IBaseResponse<Order>> UpdateOrder(int orderId, OrderViewModel model);
    }
}
