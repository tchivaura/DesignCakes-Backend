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
    public class ProductSizeRepository(DesignCakesDbContext dbContext) : IProductSizeRepository
    {
        public async Task<IEnumerable<ProductSizes>> GetAllSizes()
        {
            return await dbContext.ProductSizes.ToListAsync();
        }
    }
}
