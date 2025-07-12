using DesignCakesApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignCakesApp.Core.Interfaces
{
    public  interface IPaymentsTypesRepository 
    {
        Task<IEnumerable<PaymentTypes>> GetAllPaymentTypes();
        Task<PaymentTypes> AddNewPaymentTypeAsyn(PaymentTypes payment);
        Task<PaymentTypes> UpdatePaymentTypeAsync(int paymenttypeid, PaymentTypes paymenttypes);
       
    }

}

