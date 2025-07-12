using DesignCakesApp.Core.Entities;
using DesignCakesApp.Core.Interfaces;
using DesignCakesApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignCakesApp.Infrastructure.Repository
{
    public class ProductPricesRepository(DesignCakesDbContext dbContext) : IProductPricesRepository
    {
        public async Task<IEnumerable<ProductPrices>> GetAllProductPrices()
        {
            return await dbContext.ProductPrices.ToListAsync();
        }
        public async Task<ProductPrices> AddNewProductPriceAsyn(ProductPrices productPrices)
        {
            dbContext.ProductPrices.Add(productPrices);
            await dbContext.SaveChangesAsync();
            return productPrices;
        }

        public async Task<ProductPrices> UpdateProductPriceAsyn(int productpriceid, ProductPrices entity)
        {
            var productprice= await dbContext.ProductPrices.FirstOrDefaultAsync(x => x.id == productpriceid);
            if (productprice is not null)
            {


                productprice.ProductId=entity.ProductId;
                productprice.Price=entity.Price;
                productprice.SizeId=entity.SizeId;
                
                await dbContext.SaveChangesAsync();

                return productprice;
            }
            return productprice;
        }

    }



}
