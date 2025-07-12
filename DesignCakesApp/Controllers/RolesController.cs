using DesignCakesApp.Core.Entities;
using DesignCakesApp.Core.Interfaces;
using DesignCakesApp.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DesignCakesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _rolesRepository;


        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository=rolesRepository;
        }

        [HttpGet]

        public async Task<IEnumerable<Roles>> GetAll()
        {
            var roles = await _rolesRepository.GetAllRoles();
            return roles;
        }
    }
}
