using ShopApi.Models;

namespace ShopApi.Services.SupplierServices
{
    public interface ISupplierServices
    {
        Task<List<Supplier>> GetAllSupplier();
        Task<Supplier?> GetSingleSupplier(int id);
        Task<List<Supplier>?> AddSupplier(Supplier supplier);
        Task<List<Supplier>?> UpdateSupplier(int id,Supplier supplier);
        Task<List<Supplier>?> DeleteSupplier(int id);
    }
}
