using DesignCakesApp.Core.DTOs;
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
    public class LovedOnesRepository(DesignCakesDbContext dbContext) :ILovedOnesRepository
    {
        public async Task<IEnumerable<LovedOnes>> GetAllLovedOnes(int customerid)
        {
            return await dbContext.LovedOnes.Where(x=>x.CustomerId==customerid).ToListAsync();
        }
        public async Task<LovedOnes> AddNewLovedOneAsyn(LovedOnes lovedone)
        {
            dbContext.LovedOnes.Add(lovedone);
            await dbContext.SaveChangesAsync();
            return lovedone;
        }
        public async Task<LovedOnes> UpdateLovedOneAsync(int lovedoneid, LovedOnes entity)
        {
            var lovedone = await dbContext.LovedOnes.FirstOrDefaultAsync(x => x.Id == lovedoneid);
            if ( lovedone != null)
            {


                lovedone.FullName=entity.FullName;
                lovedone.CustomerId = entity.CustomerId;
                lovedone.Relationship=entity.Relationship;
                lovedone.Contact=entity.Contact;
                lovedone.DOB=entity.DOB;
                lovedone.gender = entity.gender;
                
                await dbContext.SaveChangesAsync();

                return lovedone;
            }
            return lovedone;
        }
        public async Task<bool> DeleteLovedOneAsync(int lovedoneid)
        {
            var lovedone = await dbContext.LovedOnes.FirstOrDefaultAsync(x => x.Id == lovedoneid);
            if (lovedone is not null)
            {
                dbContext.LovedOnes.Remove(lovedone);
                return await dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }
        public async Task<IEnumerable<UpcomingBirthdayDto>> GetUpcomingBirthdaysAsync()
        {
            var today = DateTime.Today;
            var start = today.AddDays(7);
            var end = today.AddDays(14);

            var lovedOnes = await dbContext.LovedOnes.ToListAsync();

            var upcomingBirthdays = lovedOnes
                .Where(lo =>
                {
                    if (string.IsNullOrWhiteSpace(lo.DOB))
                        return false;

                    if (!DateTime.TryParse(lo.DOB, out var dob))
                        return false;

                    var nextBirthday = new DateTime(today.Year, dob.Month, dob.Day);

                    if (nextBirthday < today)
                        nextBirthday = nextBirthday.AddYears(1);

                    return nextBirthday >= start && nextBirthday <= end;
                })
                .Select(lo =>
                {
                    var dob = DateTime.Parse(lo.DOB!);
                    var nextBirthday = new DateTime(today.Year, dob.Month, dob.Day);

                    if (nextBirthday < today)
                        nextBirthday = nextBirthday.AddYears(1);

                    int ageTurning = nextBirthday.Year - dob.Year;

                    return new UpcomingBirthdayDto
                    {
                        LovedOneName = lo.FullName ?? "Unnamed",
                        NextBirthday = nextBirthday,
                        DayOfWeek = nextBirthday.DayOfWeek.ToString(),
                        customerId = lo.CustomerId,
                        AgeTurning = ageTurning,
                        Relationship = lo.Relationship ?? "Unknown",
                        gender = lo.gender ?? "Not Specified"
                    };
                })
                .ToList();

            return upcomingBirthdays;
        }




        public async Task<LovedOnes?> GetLovedOneById(int id)
        {
            return await dbContext.LovedOnes.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<IEnumerable<LovedOnes>> GetAll()
        {
            return await dbContext.LovedOnes.ToListAsync();
        }



    }
}

