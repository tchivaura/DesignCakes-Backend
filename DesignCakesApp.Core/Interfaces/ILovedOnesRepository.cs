using DesignCakesApp.Core.DTOs;
using DesignCakesApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignCakesApp.Core.Interfaces
{
    public  interface ILovedOnesRepository
    {
        Task<IEnumerable<LovedOnes>> GetAllLovedOnes(int customerid);
        Task<LovedOnes> AddNewLovedOneAsyn(LovedOnes lovedone);
        Task<LovedOnes> UpdateLovedOneAsync(int lovedoneid, LovedOnes lovedOnes);
        Task<bool> DeleteLovedOneAsync(int lovedoneid);
        Task<IEnumerable<UpcomingBirthdayDto>> GetUpcomingBirthdaysAsync();

        Task<LovedOnes> GetLovedOneById(int id);

        Task<IEnumerable<LovedOnes>> GetAll();
    }
}
