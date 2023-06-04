using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Models;
using ShopApi.Services.OderServices;
using System.Runtime.InteropServices;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrderController( IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }
        [HttpGet, Authorize()]
        public async Task<ActionResult<List<Order>?>> GetAllOrder()
        {
            return await _orderServices.GetAllOrder();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetSingleOrder(int id)
        {
            var result = await _orderServices.GetSingleOrder(id);
            if (result is null)
                return null;
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<Order>?>> AddOrder(Order order)
        {
            var result = await _orderServices.AddOrder(order);
            if (result is null)
                return NotFound("Order not found");
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Order>?>> DeleteOrder(int id)
        {
            var result = await _orderServices.DeleteOrder(id);
            if (result is null)
                return NotFound("Order not found");
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Order>?>> UpdateOrder(int id, Order order)
        {
            var result = await _orderServices.UpdateOrder(id, order);
            if (result is null)
                return NotFound("Order not found");
            return Ok(result);
        }

    }
}
