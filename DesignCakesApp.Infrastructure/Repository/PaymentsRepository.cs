using DesignCakesApp.Core.Entities;
using DesignCakesApp.Core.Interfaces;
using DesignCakesApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignCakesApp.Infrastructure.Repository
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly DesignCakesDbContext dbContext;

        public PaymentsRepository(DesignCakesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

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
            return null;
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

        public async Task<IEnumerable<Payments>> GetPaymentsByDescription(string description)
        {
            return await dbContext.Payments
                .Where(payment => payment.description == description)
                .ToListAsync();
        }

        public async Task<IEnumerable<Payments>> GetAllPaymentsByDate(string date)
        {
            if (!DateTime.TryParse(date, out DateTime parsedDate))
                return Enumerable.Empty<Payments>();

            var payments = await dbContext.Payments.ToListAsync();
            return payments
                .Where(pay => DateTime.TryParse(pay.date, out var payDate) && payDate.Date == parsedDate.Date)
                .ToList();
        }

        /// <summary>
        /// Returns the total balance of payments before a specific date.
        /// paymenttype = 0 means all types.
        /// </summary>
        public async Task<double> GetBalance(string startdate, string paymenttype)
        {
            var payments = await dbContext.Payments.ToListAsync();

            DateTime? start = null;
            if (!string.IsNullOrWhiteSpace(startdate) && DateTime.TryParse(startdate, out DateTime s))
                start = s.Date;

            int paymentTypeId = 0;
            if (!string.IsNullOrWhiteSpace(paymenttype) && int.TryParse(paymenttype, out int parsedType))
                paymentTypeId = parsedType;

            var filtered = payments.Where(p =>
            {
                if (!DateTime.TryParse(p.date, out DateTime payDate))
                    return false;

                if (start.HasValue && payDate.Date >= start.Value)
                    return false;

                // Only filter by payment type if paymentTypeId != 0
                if (paymentTypeId != 0 && p.paymenttype != paymentTypeId.ToString())
                    return false;

                return true;
            });

            double total = 0;
            foreach (var pay in filtered)
            {
                try
                {
                    total += Convert.ToDouble(pay.amount);
                }
                catch
                {
                    // Ignore invalid amounts
                }
            }

            return total;
        }
    }
}
