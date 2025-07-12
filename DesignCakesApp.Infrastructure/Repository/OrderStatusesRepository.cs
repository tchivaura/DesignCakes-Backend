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
   public class OrderStatusesRepository(DesignCakesDbContext dbContext) :IOrderStatusesRepository
    {
        public async Task<IEnumerable<OrderStatuses>> GetAllStatuses()
        {
            return await dbContext.OrderStatuses.ToListAsync();
        }
    }
}
