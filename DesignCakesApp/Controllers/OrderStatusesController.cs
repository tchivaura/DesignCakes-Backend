using DesignCakesApp.Core.Entities;
using DesignCakesApp.Core.Interfaces;
using DesignCakesApp.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignCakesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderStatusesController : ControllerBase
    {
       private readonly IOrderStatusesRepository _orderStatusesRepository;

        public OrderStatusesController(IOrderStatusesRepository orderStatusesRepository)
        {
            orderStatusesRepository = orderStatusesRepository;
        }

        [HttpGet]

        public async Task<IEnumerable<OrderStatuses>> GetAll()
        {
            var orderStatuses = await _orderStatusesRepository.GetAllStatuses();
            return orderStatuses;
        }


    }
}
