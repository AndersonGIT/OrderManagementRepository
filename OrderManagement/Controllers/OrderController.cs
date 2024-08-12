﻿using Domain.Entities;
using Domain.Ports.IOrder;
using Microsoft.AspNetCore.Mvc;

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
            var orders = await _orderService.GetOrListOrderAsync(0);

            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            if (orderId <= 0) return BadRequest();

            var orders = await _orderService.GetOrListOrderAsync(orderId);

            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> InserOrder([FromBody] Order order)
        {
            var orderInserted = await _orderService.InsertOrderAsync(order);

            return Ok(orderInserted);
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateOrder(int orderId, [FromBody] Order order)
        {
            if (orderId != order?.Id) return BadRequest();

            var orderUpdated = await _orderService.UpdateOrderAsync(order);

            return Ok(orderUpdated);
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
