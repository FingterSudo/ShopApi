using Microsoft.EntityFrameworkCore;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Services.OrderItemServices
{
    public class OrderItemServices: IOrderItemServices
    {
        private readonly ShopDatabaseContext _context;
        public OrderItemServices(ShopDatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<OrderItem>> GetAllOrderItem()
        {
            return await _context.OrderItems.ToListAsync();
        }
        public async Task<OrderItem> GetSingleOrderItem(int id)
        {
            var result = await _context.OrderItems.FindAsync(id);
            if (result is null)
                return null;
            return result; 
        }
        public async Task<List<OrderItem>?> AddOrderItem(OrderItem orderItem)
        {
            var result = await _context.OrderItems.AddAsync(orderItem);
            if(result is null)
                return null;
            return _context.OrderItems.ToList();
        }
        public async Task<List<OrderItem>?> UpdateOrderItem(int id, OrderItem orderItem)
        {
            var result =  _context.OrderItems.Find(id);
            if (result is null)
                return null;
            result.OrderId = orderItem.OrderId;
            result.ProductId = orderItem.ProductId;
            result.UnitPrice = orderItem.UnitPrice;
            result.Quantity = orderItem.Quantity;
            await _context.SaveChangesAsync();
            return _context.OrderItems.ToList();
        }
        public async Task<List<OrderItem>?> DeleteOrderItem(int id)
        {
            var result = await _context.OrderItems.FindAsync(id);
            if (result is null)
                return null;
            _context.OrderItems.Remove(result);
            await _context.SaveChangesAsync();
            return _context.OrderItems.ToList();
        }
    }
}
