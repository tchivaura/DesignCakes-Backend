using DesignCakesApp.Core.Entities;
using DesignCakesApp.Core.Interfaces;
using DesignCakesApp.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignCakesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository=productsRepository;
        }

        [HttpGet]

        public async Task<IEnumerable<Products>> GetAll()
        {
            var products = await _productsRepository.GetAllProducts();
            return products;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromBody] Products product)
        {
            var created = await _productsRepository.AddNewProductAsyn(product);
            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }


        




    }
}
