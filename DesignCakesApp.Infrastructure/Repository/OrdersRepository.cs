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
    public class OrdersRepository(DesignCakesDbContext dbContext):IOrdersRepository
    {
        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            return await dbContext.Orders.ToListAsync();
        }
        public async Task<Orders> AddNewOrderAsyn(Orders order)
        {
            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync();
            return order;
        }
        public async Task<Orders> UpdateOrderAsync(int orderid, Orders entity)
        {
            var order = await dbContext.Orders.FirstOrDefaultAsync(x => x.id == orderid);
            if (order != null)
            {

                order.orderproduct = entity.orderproduct;
                order.size= entity.size;
                order.price= entity.price;
                order.extrainstructions= entity.extrainstructions;
                order.clerk=entity.clerk;
                order.occasion=entity.occasion;
                order.customerid=entity.customerid;
                order.orderdate=entity.orderdate;
                order.orderperson=entity.orderperson;
                order.orderstatus=entity.orderstatus;
                
                
                await dbContext.SaveChangesAsync();

                return order;
            }
            return order;
        }
        public async Task<bool> DeleteOrderAsync(int orderid)
        {
            var order= await dbContext.Orders.FirstOrDefaultAsync(x => x.id == orderid);
            if (order is not null)
            {
                dbContext.Orders.Remove(order);
                return await dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Orders>> GetOrdersByCustomer(int customerid)
        {
            return await dbContext.Orders.Where(x=>x.customerid==customerid).ToListAsync();
        }

        public async Task<Orders?> PatchOrderStatusAsync(int orderId, string newStatus)
        {
            var order = await dbContext.Orders.FirstOrDefaultAsync(x => x.id == orderId);
            if (order is null) return null;

            order.orderstatus = newStatus;
            await dbContext.SaveChangesAsync();

            return order;
        }

        public async Task<IEnumerable<Orders>> GetAllByDate(string date)
        {
            if (!DateTime.TryParse(date, out DateTime parsedDate))
                return Enumerable.Empty<Orders>();

            // Pull data from DB first (no DateTime.Parse in the SQL)
            var orders = await dbContext.Orders.ToListAsync();

            // Filter in-memory using parsed dates
            return orders.Where(ord => DateTime.TryParse(ord.orderdate, out var orderDate) && orderDate.Date == parsedDate.Date);
        }



    }
}
