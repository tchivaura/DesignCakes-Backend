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
    public  class PaymentsRepository(DesignCakesDbContext dbContext) :IPaymentsRepository
    {
        public async Task<IEnumerable<Payments>> GetAllPayments()
        {
            return await dbContext.Payments.ToListAsync();
        }
        public async Task<Payments> AddNewPaymentAsyn(Payments payment)
        {
            dbContext.Payments.Add(payment);
            await dbContext.SaveChangesAsync();
            return payment;
        }

        public async Task<Payments> UpdatePaymentAsync(int paymentid, Payments entity)
        {
            var payment = await dbContext.Payments.FirstOrDefaultAsync(x => x.id == paymentid);
            if (payment is not null)
            {


                payment.orderid = entity.orderid;
                payment.date = entity.date;
                payment.amount = entity.amount;
                payment.paymenttype = entity.paymenttype;
                payment.clerk = entity.clerk;
                payment.supplier = entity.supplier;
                await dbContext.SaveChangesAsync();

                return payment;
            }
            return payment;
        }
        public async Task<bool> DeletePaymentAsync(int paymentid)
        {
            var payment = await dbContext.Payments.FirstOrDefaultAsync(x => x.id == paymentid);
            if (payment is not null)
            {
                dbContext.Payments.Remove(payment);
                return await dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }
        public async Task<IEnumerable<Payments>> GetAllPaymentsByOrderId(int orderId)
        {
            return await dbContext.Payments
                .Where(p => p.orderid == orderId)
                .ToListAsync();
        }

        public   async Task<IEnumerable<Payments>> GetPaymentsByDescription(string description)
        {
            return await dbContext.Payments.Where(payment => payment.description == description).ToListAsync();
        }

        public async Task<IEnumerable<Payments>> GetAllPaymentsByDate(string date)
        {
            if (!DateTime.TryParse(date, out DateTime parsedDate))
                return Enumerable.Empty<Payments>();

            var payments = await dbContext.Payments.ToListAsync();

            return payments
                .Where(pay => DateTime.TryParse(pay.date, out var payDate) && payDate.Date == parsedDate.Date);
        }


    }

}
