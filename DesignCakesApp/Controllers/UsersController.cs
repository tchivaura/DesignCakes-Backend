using DesignCakesApp.Core.Entities;
using DesignCakesApp.Core.Interfaces;
using DesignCakesApp.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DesignCakesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUsersRepository _usersRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository=usersRepository;
        }
        [HttpGet]

        public async Task<IEnumerable<Users>> GetAll()
        {
            var users = await _usersRepository.GetAllUsers();
            return users;
        }

        [HttpPost]
        public async Task<Users> AddNewUser([FromBody] Users user)
        {
            var created = await _usersRepository.AddNewUserAsyn(user);
            return created;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] Users user)
        {
            var updated = await _usersRepository.UpdateUserAsync(id, user);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }
    }
}
