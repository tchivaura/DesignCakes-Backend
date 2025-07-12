using DesignCakesApp.Core.Entities;
using DesignCakesApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesignCakesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]

        public async Task<IEnumerable<Customers>> GetAll()
        {
            var customers = await _customerRepository.GetAllCustomers();
            return customers;
        }

        [HttpPost]
        public async Task<Customers> AddCustomer([FromBody] Customers customer)
        {
            var created = await _customerRepository.AddNewCustomerAsyn(customer);
            return created;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customers customer)
        {
            var updated = await _customerRepository.UpdateCustomerAsync(id, customer);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var deleted = await _customerRepository.DeleteCustomerAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomerbyid(int id)
        {
            var customer = await _customerRepository.GetCustomer(id);
            if (customer == null)
            {
                return NotFound(); // This ensures middleware (like CORS) is properly applied
            }

            return Ok(customer);
        }

    }

}
