using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WoodStore.Domain.Entity;
using WoodStore.Domain.Response;

namespace WoodStore.Service.Interfaces
{
    public interface IOrderService
    {
        Task<IBaseResponse<IEnumerable<Order>>> GetAllOrders();
    }
}
