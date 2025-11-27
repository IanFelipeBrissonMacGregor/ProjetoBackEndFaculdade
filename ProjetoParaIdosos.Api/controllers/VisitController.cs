using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoBackEnd.Api.Models;
using ProjetoBackEnd.Api.Services.Interfaces;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _service;
        public VisitController(IVisitService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var visit = await _service.GetByIdAsync(id);
            if (visit == null) return NotFound();
            return Ok(visit);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Visit visit)
        {
            var created = await _service.CreateAsync(visit);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Visit visit)
        {
            if (id != visit.Id) return BadRequest();
            await _service.UpdateAsync(visit);
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
