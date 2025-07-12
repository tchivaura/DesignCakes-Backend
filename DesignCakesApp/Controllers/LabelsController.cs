using DesignCakesApp.Core.Entities;
using DesignCakesApp.Core.Interfaces;
using DesignCakesApp.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DesignCakesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabelsController: ControllerBase
    {
        private readonly ILabelsRepository _labelsRepository;

        public LabelsController(ILabelsRepository labelsRepository)
        {
            _labelsRepository= labelsRepository;
        }

        [HttpGet]

        public async Task<IEnumerable<Labels>> GetAll()
        {
            var labels = await _labelsRepository.GetAllLabels();
            return labels;
        }
    }
}
