using DesignCakesApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignCakesApp.Core.Interfaces
{
    public  interface IOrdersRepository
    {
        Task<IEnumerable<Orders>> GetAllOrders();
        Task<Orders> AddNewOrderAsyn(Orders order);
        Task<Orders> UpdateOrderAsync(int orderid, Orders order);
        Task<bool> DeleteOrderAsync(int orderid);

        Task<IEnumerable<Orders>> GetOrdersByCustomer(int customerid);

        Task<Orders?> PatchOrderStatusAsync(int orderId, string newStatus);

        Task<IEnumerable<Orders>> GetAllByDate(string date);

    }
}
