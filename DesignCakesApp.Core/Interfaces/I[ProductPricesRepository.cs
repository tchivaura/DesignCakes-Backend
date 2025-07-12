using DesignCakesApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignCakesApp.Core.Interfaces
{
    public interface IProductPricesRepository
    {
        Task<IEnumerable<ProductPrices>> GetAllProductPrices();
        Task<ProductPrices> AddNewProductPriceAsyn(ProductPrices productprice);
        Task<ProductPrices> UpdateProductPriceAsyn(int productpriceid, ProductPrices productPrices);

    }
}
