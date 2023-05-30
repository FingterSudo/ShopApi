using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Models;
using ShopApi.Services.OrderItemServices;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemServices _orderItemServices;
        public  OrderItemController(IOrderItemServices orderItemServices)
        {
            _orderItemServices = orderItemServices;
        }
        [HttpGet]
        public async Task<ActionResult<List<OrderItem>>> GetAllOrderItem()
        {
            return await _orderItemServices.GetAllOrderItem();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetSingleOrderItem(int id)
        {
            var result = await _orderItemServices.GetSingleOrderItem(id);
            if (result is null)
                return NotFound("OrderItem not found");
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<OrderItem>?>> AddOrderItem(OrderItem order)
        {
            var result = await _orderItemServices.AddOrderItem(order);
            if (result is null)
                return null;
            return Ok(result);
        }
        [HttpPut("{id}")] 
        public async Task<ActionResult<List<OrderItem>?>> UpdateOrderItem(int id, OrderItem orderItem)
        {
            var result = await _orderItemServices.UpdateOrderItem(id, orderItem);
            if (result is null)
                return NotFound("OrderItem not found");
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<OrderItem>?>> DeleteOrderItem(int id)
        {
            var result = await _orderItemServices.DeleteOrderItem(id);
            if (result is null)
                return NotFound("OrderItem not found");
            return Ok(result);
        }
    }
}
