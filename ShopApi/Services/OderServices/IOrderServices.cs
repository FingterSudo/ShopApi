using ShopApi.Models;

namespace ShopApi.Services.OderServices
{
    public interface IOrderServices
    {
        Task<List<Order>> GetAllOrder();
        Task<Order> GetSingleOrder(int id);
        Task<List<Order>?> AddOrder(Order order);
        Task <List<Order>?> UpdateOrder(int id, Order order);
        Task<List<Order>?> DeleteOrder(int id);
    }
}
