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
    public  class UsersRepository(DesignCakesDbContext dbContext) :IUsersRepository
    {
        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            return await dbContext.Users.ToListAsync();
        }
        
        public async Task<Users> AddNewUserAsyn(Users user)
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<Users> UpdateUserAsync(int userid, Users entity)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.id == userid);
            if (user != null)
            {


                user.firstName=entity.firstName;
                user.lastName=entity.lastName;
                user.password=entity.password;
                user.Role = entity.Role;
                
                await dbContext.SaveChangesAsync();

                return user;
            }
            return user;
        }

    }
}
