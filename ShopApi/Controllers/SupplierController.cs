using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Models;
using ShopApi.Services.SupplierServices;
using System.Runtime.InteropServices;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierServices _supplierServices;
        public SupplierController(ISupplierServices supplierServices)
        {
            _supplierServices = supplierServices;
        }
        [HttpGet]
        public async Task<ActionResult<List<Supplier>>> GetAllSupplier() 
        {
            return await _supplierServices.GetAllSupplier();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSingleSupplier(int id)
        {
            var result = await _supplierServices.GetSingleSupplier(id);
            if (result is null)
                return NotFound("Supplier not found");
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<Supplier>?>> AddSupplier(Supplier supplier)
        {
            return await _supplierServices.AddSupplier(supplier);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Supplier>?>> UpdateSupplier(int id, Supplier supplier)
        {
            var result = await _supplierServices.UpdateSupplier(id, supplier);
            if (result is null)
                return NotFound("Supplier not found");
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Supplier>?>> DeleteSupplier(int id)
        {
            var result = await _supplierServices.DeleteSupplier(id);
            if (result is null)
                return NotFound("Supplier not found");
            return Ok(result);
        }
    }
}
