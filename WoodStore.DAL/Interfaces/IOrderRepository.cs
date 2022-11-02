using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WoodStore.Domain.Entity;

namespace WoodStore.DAL.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> GetByDate(DateTime orderDate);

    }
}
