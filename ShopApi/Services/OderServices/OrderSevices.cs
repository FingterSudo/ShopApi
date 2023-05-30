using Microsoft.EntityFrameworkCore;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Services.OderServices
{
    public class OrderSevices: IOrderServices
    {
        private readonly ShopDatabaseContext _context;
        public async Task<List<Order>> GetAllOrder()
        {
            return await _context.Orders.ToListAsync();
        }
        public async Task<Order> GetSingleOrder(int id)
        {
            var result = await _context.Orders.FindAsync(id);
            if (result == null)
                return null;
            return result;
        }
        public async Task<List<Order>?> AddOrder(Order order)
        {
            var reult = await _context.Orders.AddAsync(order);
            if(reult == null)
                return null;
            await _context.SaveChangesAsync();
            return _context.Orders.ToList();
        }
        public async Task<List<Order>?> DeleteOrder(int id)
        {
            var result = await _context.Orders.FindAsync(id);
            if (result == null)
                return null;
            _context.Orders.Remove(result);
            await _context.SaveChangesAsync();
            return _context.Orders.ToList();
        }
        public async Task<List<Order>?> UpdateOrder(int id, Order order)
        {
            var Order = await _context.Orders.FindAsync(id);
            if (Order == null)
                return null;
            Order.OrderDate = order.OrderDate;
            Order.OrderNumber = order.OrderNumber;
            Order.CustomerId = order.CustomerId;
            Order.TotalAmount = order.TotalAmount;
            await _context.SaveChangesAsync();
            return _context.Orders.ToList();
        }
    }
}
