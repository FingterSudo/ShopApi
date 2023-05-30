using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Models;
using ShopApi.Services.CustomerServices;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerServices _customerServices;
        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomer()
        {
            return await _customerServices.GetAllCustomer();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetSingleCustomer(int id)
        {
            var result = await _customerServices.GetSingleCustomer(id);
            if (result is null)
                return NotFound("Customer not found");
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer(Customer customer)
        {
            var result = await _customerServices.AddCustomer(customer);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(int id, Customer request)
        {
            var result = await _customerServices.UpdateCustomer(id, request);
            if (result is null)
                return NotFound("Customer not found");
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            var result = await _customerServices.DeleteCustomer(id);
            if (result is null)
                return NotFound("Customer not found");
            return Ok(result);
        }
    }
}
