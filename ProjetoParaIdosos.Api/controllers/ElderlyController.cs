using Microsoft.AspNetCore.Mvc;
using ProjetoBackEnd.Api.Models;
using ProjetoBackEnd.Api.Services.Interfaces;

namespace ProjetoBackEnd.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElderlyController : ControllerBase
    {
        private readonly IElderlyService _service;
        public ElderlyController(IElderlyService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var elderly = await _service.GetByIdAsync(id);
            if (elderly == null) return NotFound();
            return Ok(elderly);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Elderly elderly)
        {
            var created = await _service.CreateAsync(elderly);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Elderly elderly)
        {
            if (id != elderly.Id) return BadRequest();
            await _service.UpdateAsync(elderly);
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
