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
    public class ProductsRepository(DesignCakesDbContext dbContext) :IProductsRepository
    {
        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            return await dbContext.Products.ToListAsync();
        }
        public async Task<Products> AddNewProductAsyn(Products product)
        {
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            return product;
        }
    }
}
