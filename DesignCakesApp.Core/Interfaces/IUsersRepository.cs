using DesignCakesApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignCakesApp.Core.Interfaces
{
    public  interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetAllUsers();
        Task<Users> AddNewUserAsyn(Users user);
        Task<Users> UpdateUserAsync(int userid, Users user);
        

    }
}
