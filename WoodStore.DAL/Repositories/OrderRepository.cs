using System;
using System.Collections.Generic;
using System.Text;
using WoodStore.Domain.Entity;
using WoodStore.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace WoodStore.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _db;

        public OrderRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Order entity)
        {
            await _db.Order.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;

        }

        public async Task<bool> Delete(Order entity)
        {
            _db.Order.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Order> GetByDate(DateTime orderDate)
        {
            return await _db.Order.FirstOrDefaultAsync(order => order.OrderDate == orderDate);
        }

        public async Task<Order> Get(int orderID)
        {
            return await _db.Order.FirstOrDefaultAsync(order => order.OrderID == orderID);
        }

        public async Task<List<Order>> Select()
        {
            return await _db.Order.ToListAsync();
        }
    }
}
