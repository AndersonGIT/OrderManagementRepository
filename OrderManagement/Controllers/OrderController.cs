using Domain.Entities;
using Domain.Ports.IOrder;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService) => _orderService = orderService;

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetOrListOrderOutputAsync(0);

            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            if (orderId <= 0) return BadRequest();

            var orders = await _orderService.GetOrListOrderOutputAsync(orderId);

            if (orders != null)
            {
                var order = orders.FirstOrDefault();
                return Ok(order);
            }
            else
            {
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrder([FromBody] Order order)
        {
            if (order.Validate())
            {
                var orderInserted = await _orderService.InsertOrderAsync(order);

                return Ok(orderInserted);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateOrder(int orderId, [FromBody] Order order)
        {
            if (order.Validate())
            {
                if (orderId != order?.Id) return BadRequest();

                var orderUpdated = await _orderService.UpdateOrderAsync(order);

                return Ok(orderUpdated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            if (orderId <= 0) return BadRequest();

            var orderDeleted = await _orderService.DeleteOrderAsync(orderId);

            return Ok(orderDeleted);
        }
    }
}
