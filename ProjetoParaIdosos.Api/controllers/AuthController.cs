using Microsoft.AspNetCore.Mvc;
using ProjetoBackEnd.Api.Models.DTOs;
using ProjetoBackEnd.Api.Services.Interfaces;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        public AuthController(IAuthService auth) => _auth = auth;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var user = await _auth.RegisterAsync(dto.Username, dto.Password);
            return Ok(new { user.Id, user.Username });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _auth.LoginAsync(dto.Username, dto.Password);
            if (token == null) return Unauthorized();
            return Ok(new { token });
        }
    }
}
