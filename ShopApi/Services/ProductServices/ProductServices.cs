using Microsoft.EntityFrameworkCore;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Services.ProductServices
{
    public class ProductServices : IProductServices
    {
        private readonly ShopDatabaseContext _context;
        public ProductServices(ShopDatabaseContext context) {
            _context = context;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<List<Product>?> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return  _context.Products.ToList() ;
        }
        public async Task<List<Product>?> DeleteProduct(int id)
        {
            var result = await _context.Products.FindAsync(id);
            if (result == null)
                return null;
            _context.Products.Remove(result);
            await _context.SaveChangesAsync();
            return _context.Products.ToList();
        }
        public async Task<Product?> GetSingleProduct(int id)
        {
            var result = await _context.Products.FindAsync(id);
            if (result == null)
                return null;
            return result;
        }
        public async Task<List<Product>?> UpdateProduct(int id, Product product)
        {
            var result = await _context.Products.FindAsync(id);
            if (result == null)
                return null;
            result.Supplier = product.Supplier;
            result.UnitPrice = product.UnitPrice;
            result.ProductName = product.ProductName;
            result.Package = product.Package;
            await _context.SaveChangesAsync();
            return _context.Products.ToList();
        }
    }
}
