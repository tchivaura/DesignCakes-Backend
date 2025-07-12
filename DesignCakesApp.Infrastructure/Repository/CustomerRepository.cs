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
    public  class CustomerRepository(DesignCakesDbContext dbContext) : ICustomerRepository
    {
        public async Task<IEnumerable <Customers>> GetAllCustomers()
        {
            return await dbContext.Customers.ToListAsync();
        }
        public async Task<Customers> AddNewCustomerAsyn(Customers customer)
        {
            dbContext.Customers.Add(customer);
            await dbContext.SaveChangesAsync();
            return customer;
        }
        public async Task<Customers> UpdateCustomerAsync(int customerid, Customers entity)
        {
            var  customer= await dbContext.Customers.FirstOrDefaultAsync(x=>x.id==customerid);
            if (customer != null)
            {


                customer.firstName = entity.firstName;
                customer.surname = entity.surname;
                customer.addresss = entity.addresss;
                customer.label = entity.label;
                customer.dob = entity.dob;
                customer.@base = entity.@base;
                await dbContext.SaveChangesAsync();
               
                return customer;
            }
            return customer;
        }
        public async Task<bool> DeleteCustomerAsync(int customerid)
        {
            var customer = await dbContext.Customers.FirstOrDefaultAsync(x => x.id == customerid);
            if (customer is not null)
            {
                dbContext.Customers.Remove(customer);
                return await dbContext.SaveChangesAsync() >0;
            }
            return false;
        }
         public async Task<Customers> GetCustomer (int customerid)
        {
            var customer = await dbContext.Customers.FirstOrDefaultAsync(x => x.id == customerid);
            return customer;
        }
    }
}
