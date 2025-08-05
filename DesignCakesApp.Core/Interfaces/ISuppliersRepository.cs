using DesignCakesApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignCakesApp.Core.Interfaces
{
    public  interface ISuppliersRepository
    {
        Task<IEnumerable<Suppliers>> GetAllSuppliers();
        Task<Suppliers> AddNewSupplierAsyn(Suppliers supplier);
    }
}
