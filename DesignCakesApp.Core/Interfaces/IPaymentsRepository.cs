using DesignCakesApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignCakesApp.Core.Interfaces
{
    public interface IPaymentsRepository
    {
        Task<IEnumerable<Payments>> GetAllPayments();
        Task<Payments> AddNewPaymentAsyn(Payments payment);
        Task<Payments> UpdatePaymentAsync(int paymentid, Payments payment);
        Task<bool> DeletePaymentAsync(int paymentid);

        Task<IEnumerable<Payments>> GetAllPaymentsByOrderId(int orderId);

        Task<IEnumerable<Payments>> GetPaymentsByDescription(string description);

        Task<IEnumerable<Payments>> GetAllPaymentsByDate(string date);




    }
}
