using DesignCakesApp.Core.Entities;
using DesignCakesApp.Core.Interfaces;
using DesignCakesApp.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DesignCakesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductPricesController :ControllerBase
    {
        private readonly IProductPricesRepository _productPricesRepository;

        public ProductPricesController(IProductPricesRepository productPricesRepository)
        {
            _productPricesRepository = productPricesRepository;
        }

        [HttpGet]

        public async Task<IEnumerable<ProductPrices>> GetAll()
        {
            var productprices = await _productPricesRepository.GetAllProductPrices();
            return productprices;
        }

        [HttpPost]
        public async Task<ProductPrices> ProductPrices([FromBody] ProductPrices productprices)
        {
            var created = await _productPricesRepository.AddNewProductPriceAsyn(productprices);
            return created;
        }
        [HttpPut("{id}")]
        public async Task<ProductPrices> UpdateProductPrice(int id, [FromBody] ProductPrices productPrices)
        {
            var updated = await _productPricesRepository.UpdateProductPriceAsyn(id, productPrices);


            return updated;
        }
        
    }
}
