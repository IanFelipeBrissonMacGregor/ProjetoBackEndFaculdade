using Microsoft.AspNetCore.Mvc;
using ProjetoBackEnd.Api.Models;
using ProjetoBackEnd.Api.Services.Interfaces;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerService _service;
        public PartnerController(IPartnerService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var partner = await _service.GetByIdAsync(id);
            if (partner == null) return NotFound();
            return Ok(partner);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Partner partner)
        {
            var created = await _service.CreateAsync(partner);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Partner partner)
        {
            if (id != partner.Id) return BadRequest();
            await _service.UpdateAsync(partner);
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
