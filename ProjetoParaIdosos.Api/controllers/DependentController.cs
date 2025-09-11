using Microsoft.AspNetCore.Mvc;
using ProjetoBackEnd.Api.Models;
using ProjetoBackEnd.Api.Services.Interfaces;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DependentController : ControllerBase
    {
        private readonly IDependentService _service;
        public DependentController(IDependentService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dependent = await _service.GetByIdAsync(id);
            if (dependent == null) return NotFound();
            return Ok(dependent);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Dependent dependent)
        {
            var created = await _service.CreateAsync(dependent);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Dependent dependent)
        {
            if (id != dependent.Id) return BadRequest();
            await _service.UpdateAsync(dependent);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
