using ShopApi.Models;

namespace ShopApi.Services.CustomerServices
{
    public interface ICustomerServices
    {
        Task<List<Customer>> GetAllCustomer();
        Task<Customer?> GetSingleCustomer(int id);
        Task<List<Customer>?> AddCustomer(Customer customer);
        Task<List<Customer>?> UpdateCustomer(int id, Customer request);
        Task<List<Customer>?> DeleteCustomer(int id);
    }
}
