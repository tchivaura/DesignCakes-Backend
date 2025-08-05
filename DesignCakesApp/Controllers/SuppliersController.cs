using DesignCakesApp.Core.Entities;
using DesignCakesApp.Core.Interfaces;
using DesignCakesApp.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignCakesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuppliersController : ControllerBase
    {
        private ISuppliersRepository _suppliersRepository;

        public SuppliersController(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        [HttpGet]

        public async Task<IEnumerable<Suppliers>> GetAll()
        {
            var suppliers = await _suppliersRepository.GetAllSuppliers();
            return suppliers;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewSupplier([FromBody] Suppliers supplier)
        {
            var created = await _suppliersRepository.AddNewSupplierAsyn(supplier);
            return CreatedAtAction(nameof(GetAll), new { id = created.id }, created);
        }







    }
}
