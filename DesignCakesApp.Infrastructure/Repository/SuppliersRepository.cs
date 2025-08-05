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
    public  class SuppliersRepository(DesignCakesDbContext dbContext) : ISuppliersRepository
    {
        public async Task<IEnumerable<Suppliers>> GetAllSuppliers() 
        {
            return await dbContext.Suppliers.ToListAsync();
        }
        public async Task<Suppliers> AddNewSupplierAsyn(Suppliers supplier)
        {
            dbContext.Suppliers.Add(supplier);
            await dbContext.SaveChangesAsync();
            return supplier;
        }
    }
}
