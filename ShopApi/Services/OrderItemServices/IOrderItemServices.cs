using ShopApi.Models;

namespace ShopApi.Services.OrderItemServices
{
    public interface IOrderItemServices
    {
        Task<List<OrderItem>> GetAllOrderItem();
        Task<OrderItem> GetSingleOrderItem(int id);
        Task<List<OrderItem>?> AddOrderItem(OrderItem orderItem);
        Task<List<OrderItem>?> DeleteOrderItem(int id);
        Task<List<OrderItem>?> UpdateOrderItem(int id, OrderItem orderItem);
    }
}
