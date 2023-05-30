using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApi.Data;
using ShopApi.Models;
using ShopApi.Services.ProductServices;
using System.Runtime.InteropServices;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProduct()
        {
            return await _productServices.GetAllProduct();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product?>> GetSingleProduct(int id)
        {
            var result = await _productServices.GetSingleProduct(id);
            if (result is null)
                return NotFound("Product not found");
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var result = await _productServices.DeleteProduct(id);
            if (result is null)
                return NotFound("Product not found");
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<Product>?>> AddProduct(Product product)
        {
            var result = await _productServices.AddProduct(product);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Product>>> UpdateProduct(int id, Product product)
        {
            var result = await _productServices.UpdateProduct(id, product);
            if (result is null)
                return NotFound("Product not found");
            return Ok(result);
        }
    }
}
