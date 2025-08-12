using DesignCakesApp.Core.Entities;
using DesignCakesApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesignCakesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsRepository _paymentsRepository;

        public PaymentsController(IPaymentsRepository paymentsRepository)
        {
            _paymentsRepository = paymentsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Payments>> GetAllPayemnts()
        {
            var payments = await _paymentsRepository.GetAllPayments();
            return payments;
        }

        [HttpPost]
        public async Task<Payments> AddNewPayment([FromBody] Payments payment)
        {
            var created = await _paymentsRepository.AddNewPaymentAsyn(payment);
            return created;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, [FromBody] Payments payment)
        {
            var updated = await _paymentsRepository.UpdatePaymentAsync(id, payment);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var deleted = await _paymentsRepository.DeletePaymentAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Payments>> GetPaymentsByOrder(int id)
        {
            var payments = await _paymentsRepository.GetAllPaymentsByOrderId(id);
            return payments;
        }

        [HttpGet("bydescription/{description}")]
        public async Task<IEnumerable<Payments>> GetPaymentsByDescription(string description)
        {
            var payments = await _paymentsRepository.GetPaymentsByDescription(description);
            return payments;
        }

        // 🔹 NEW: Get total balance before a certain date and optional payment type
        [HttpGet("balance")]
        public async Task<ActionResult<double>> GetBalance([FromQuery] string startdate, [FromQuery] string paymenttype)
        {
            var total = await _paymentsRepository.GetBalance(startdate, paymenttype);
            return Ok(total);
        }
    }
}
