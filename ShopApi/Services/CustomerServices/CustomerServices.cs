using Microsoft.EntityFrameworkCore;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Services.CustomerServices
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ShopDatabaseContext _context;
        public CustomerServices(ShopDatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<Customer>?> AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return _context.Customers.ToList();
        }

        public async Task<List<Customer>?> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer is null)
                return null;
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return _context.Customers.ToList(); ;
        }
        public async Task<Customer?> GetSingleCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer is null)
                return null;
            return customer;
        }

        public async Task<List<Customer>?> UpdateCustomer(int id, Customer request)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer is null)
                return null;
            customer.Phone = request.Phone;
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Country = request.Country;
            customer.City = request.City;
            customer.Orders = customer.Orders;
            await _context.SaveChangesAsync();
            return _context.Customers.ToList(); ;
        }

        public async Task<List<Customer>> GetAllCustomer()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

    }
}
