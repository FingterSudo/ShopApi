using ShopApi.Models;

namespace ShopApi.Services.ProductServices
{
    public interface IProductServices
    {
        Task <List<Product>> GetAllProduct();
        Task<Product?> GetSingleProduct (int id);
        Task<List<Product>?> DeleteProduct(int id);
        Task <List<Product>?> AddProduct(Product product);
        Task <List<Product>?> UpdateProduct(int id, Product product);
    }
}
