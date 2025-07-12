using DesignCakesApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignCakesApp.Core.Interfaces
{
    public  interface ICustomerRepository
    {
        Task<IEnumerable<Customers>> GetAllCustomers();
        Task<Customers> AddNewCustomerAsyn(Customers customer);
        Task<Customers> UpdateCustomerAsync(int customerid, Customers customer);
        Task <bool> DeleteCustomerAsync(int customerid);
        Task<Customers> GetCustomer(int customerid);
    }
}
