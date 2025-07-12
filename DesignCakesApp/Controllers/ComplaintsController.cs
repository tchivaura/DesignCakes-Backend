using DesignCakesApp.Core.Entities;
using DesignCakesApp.Core.Interfaces;
using DesignCakesApp.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignCakesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComplaintsController : ControllerBase
    {
        private readonly ICustomerComplaintsRepository _customerComplaintsRepository;
        public ComplaintsController(ICustomerComplaintsRepository customerComplaintsRepository)
        {
            _customerComplaintsRepository = customerComplaintsRepository;
        }

        [HttpGet]

        public async Task<IEnumerable<Complaints>> GetAll()
        {
            var customercomplaints = await _customerComplaintsRepository.GetAllComplaints();
            return customercomplaints;
        }
        [HttpPost]
        public async Task<Complaints> AddComplaint([FromBody] Complaints complaint)
        {
            var created = await _customerComplaintsRepository.AddNewComplaintAsyn(complaint);
            return created;
        }
    }
}
