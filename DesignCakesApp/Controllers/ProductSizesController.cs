using DesignCakesApp.Core.Entities;
using DesignCakesApp.Core.Interfaces;
using DesignCakesApp.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignCakesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductSizesController : ControllerBase
    {
        private readonly IProductSizeRepository _productSizeRepository;

        public ProductSizesController(IProductSizeRepository productSizeRepository)
        {
            _productSizeRepository = productSizeRepository;
        }

        [HttpGet]

        public async Task<IEnumerable<ProductSizes>> GetAll()
        {
            var ProductSizes = await _productSizeRepository.GetAllSizes();
            return ProductSizes;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProductSize([FromBody] ProductSizes productsize)
        {
            var created = await _productSizeRepository.AddNewProductSizeAsyn(productsize);
            return CreatedAtAction(nameof(GetAll), new { id = created.id }, created);


        }

    }
}
