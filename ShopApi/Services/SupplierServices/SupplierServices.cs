using Microsoft.EntityFrameworkCore;
using ShopApi.Data;
using ShopApi.Models;
using System.Runtime.InteropServices;

namespace ShopApi.Services.SupplierServices
{
    public class SupplierServices:ISupplierServices
    {
        private readonly ShopDatabaseContext _context;
        public SupplierServices(ShopDatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Supplier>?> AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return _context.Suppliers.ToList();
        }

        public async Task<List<Supplier>?> DeleteSupplier(int id)
        {
            var result = await _context.Suppliers.FindAsync(id);
            if (result is null)
                return null;
            _context.Suppliers.Remove(result);
            await _context.SaveChangesAsync();
            return _context.Suppliers.ToList();
        }

        public async Task<List<Supplier>> GetAllSupplier()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier?> GetSingleSupplier(int id)
        {
            var result = await _context.Suppliers.FindAsync(id);
            if (result is null)
                return null;
            return result;
        }

        public async Task<List<Supplier>?> UpdateSupplier(int id, Supplier supplier)
        {
            var Supplier = await _context.Suppliers.FindAsync(id);
            if (Supplier is null)
                return null;
            Supplier.Phone = supplier.Phone;
            Supplier.City = supplier.City;
            Supplier.CompanyName = supplier.CompanyName;
            Supplier.ContactName = supplier.ContactName;
            Supplier.ContactTitle = supplier.ContactTitle;
            Supplier.Country = supplier.Country;
            Supplier.Fax = supplier.Fax;
            await _context.SaveChangesAsync();
            return _context.Suppliers.ToList();
        }
    }
}
