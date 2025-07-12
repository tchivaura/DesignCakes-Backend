using DesignCakesApp.Core.DTOs;
using DesignCakesApp.Core.Entities;
using DesignCakesApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Collections;

namespace DesignCakesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LovedOnesController : ControllerBase
    {
        private readonly ILovedOnesRepository _lovedOneRepository;

        public LovedOnesController(ILovedOnesRepository lovedRepository)
        {
            _lovedOneRepository = lovedRepository;
        }

        [HttpGet("{customerid}")]

        public async Task<IEnumerable<LovedOnes>> GetAll(int customerid)
        {
            var lovedones = await _lovedOneRepository.GetAllLovedOnes(customerid);
            return lovedones;
        }

        [HttpPost]
        public async Task<LovedOnes> AddLovedOne([FromBody] LovedOnes lovedOnes)
        {
            var created = await _lovedOneRepository.AddNewLovedOneAsyn(lovedOnes);
            return created;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLovedOne(int id, [FromBody] LovedOnes lovedOnes)
        {
            var updated = await _lovedOneRepository.UpdateLovedOneAsync(id, lovedOnes);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLovedOne(int id)
        {
            var deleted = await _lovedOneRepository.DeleteLovedOneAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpGet("lovedoneid/{id}")]

        public async Task<LovedOnes> GetLovedOneById(int id)
        {
            var lovedone = await _lovedOneRepository.GetLovedOneById(id);
            return lovedone;
        }

        [HttpGet]

        public async Task<IEnumerable<LovedOnes>> FetchAll()
        {
            var lovedones = await _lovedOneRepository.GetAll();
            return lovedones;
        }

        [HttpGet("upcomingbirthdays")]

        public async Task<IEnumerable<UpcomingBirthdayDto>> GetUpComingBirthdays()
        {
            var lovedoneswithupcomingbirthdays = await _lovedOneRepository.GetUpcomingBirthdaysAsync();
            return lovedoneswithupcomingbirthdays;
        }


    }
}
