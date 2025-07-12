using DesignCakesApp.Core.Entities;
using DesignCakesApp.Core.Interfaces;
using DesignCakesApp.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DesignCakesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentTypesController :ControllerBase
    {

        private readonly IPaymentsTypesRepository _paymentTypesRepository;
        public PaymentTypesController(IPaymentsTypesRepository paymentsTypesRepository)
        {
            _paymentTypesRepository = paymentsTypesRepository;
        }


        [HttpGet]

        public async Task<IEnumerable<PaymentTypes>> GetAll()
        {
            var paymenttypes = await _paymentTypesRepository.GetAllPaymentTypes();
            return paymenttypes;
        }

        [HttpPost]
        public async Task<PaymentTypes> AddPaymentType([FromBody] PaymentTypes paymentTypes)
        {
            var created = await _paymentTypesRepository.AddNewPaymentTypeAsyn(paymentTypes);
            return created;
        }


    }
}
