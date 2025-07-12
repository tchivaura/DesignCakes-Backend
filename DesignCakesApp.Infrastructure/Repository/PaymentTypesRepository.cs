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
    public  class PaymentTypesRepository(DesignCakesDbContext dbContext) : IPaymentsTypesRepository
    {
        public async Task<IEnumerable<PaymentTypes>> GetAllPaymentTypes()
        {
            return await dbContext.PaymentTypes.ToListAsync();
        }
        public async Task<PaymentTypes> AddNewPaymentTypeAsyn(PaymentTypes paymenttypes)
        {
            dbContext.PaymentTypes.Add(paymenttypes);
            await dbContext.SaveChangesAsync();
            return paymenttypes;
        }
        public async Task<PaymentTypes> UpdatePaymentTypeAsync(int paymenttypeid, PaymentTypes entity)
        {
            var paymenttype = await dbContext.PaymentTypes.FirstOrDefaultAsync(x => x.id == paymenttypeid);
            if (paymenttype  is not null)
            {


                paymenttype.name = entity.name;
                
                await dbContext.SaveChangesAsync();

                return paymenttype;
            }
            return paymenttype;
        }
        
    }

}
