using DesignCakesApp.Core.DTOs;
using DesignCakesApp.Core.Entities;
using DesignCakesApp.Core.Interfaces;
using DesignCakesApp.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;

namespace DesignCakesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _ordersrepository;


        public OrdersController(IOrdersRepository ordersRepository)
        {
            _ordersrepository = ordersRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            var orders = await _ordersrepository.GetAllOrders();
            return orders;
        }

        [HttpPost]
        public async Task<Orders> AddNewOrder([FromBody] Orders order)
        {
            var created = await _ordersrepository.AddNewOrderAsyn(order);
            return created;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Orders order)
        {
            var updated = await _ordersrepository.UpdateOrderAsync(id, order);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var deleted = await _ordersrepository.DeleteOrderAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpGet("bycustomer/{id}")]
        public async Task<IActionResult> GetAllOrdersByCustomer(int id)
        {
            var orders = await _ordersrepository.GetOrdersByCustomer(id);
            return Ok(orders);
        }

        [HttpPatch("{orderId}")]
        public async Task<IActionResult> PatchOrderStatus(int orderId, [FromBody] OrderStatusUpdateDto dto)
        {
            var updatedOrder = await _ordersrepository.PatchOrderStatusAsync(orderId, dto.OrderStatus);
            if (updatedOrder is null) return NotFound();

            return Ok(updatedOrder);
        }

        [HttpGet("date/{date}")]
        public async Task<IEnumerable<Orders>> GetAllOrdersByDate(string date)
        {
            var todaysorder = await _ordersrepository.GetAllByDate(date);
            return todaysorder;
        }





    }
}
