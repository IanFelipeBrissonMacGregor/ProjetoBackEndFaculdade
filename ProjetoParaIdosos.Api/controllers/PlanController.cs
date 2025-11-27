using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoBackEnd.Api.Models;
using ProjetoBackEnd.Api.Services.Interfaces;

namespace ProjetoBackEnd.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _service;
        public PlanController(IPlanService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var plan = await _service.GetByIdAsync(id);
            return plan == null ? NotFound() : Ok(plan);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Plan plan)
        {
            var created = await _service.CreateAsync(plan);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Plan plan)
        {
            if (id != plan.Id) return BadRequest();
            await _service.UpdateAsync(plan);
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
