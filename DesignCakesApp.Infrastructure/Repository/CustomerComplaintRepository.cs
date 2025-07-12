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
    public class CustomerComplaintRepository(DesignCakesDbContext dbContext) : ICustomerComplaintsRepository
    {
        public async Task<Complaints> AddNewComplaintAsyn( Complaints complaint)
        {
            dbContext.Complaints.Add(complaint);
            await dbContext.SaveChangesAsync();
            return complaint;
        }

        public async Task<IEnumerable<Complaints>> GetAllComplaints()
        {
            return await dbContext.Complaints.ToListAsync();
        }
    }
}
