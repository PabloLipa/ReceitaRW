using Localiza_Aplicattion.DTO.DTO_Usuario;
using Localiza_Aplicattion.Interfaces;
using Localiza_Aplicattion.Services;
using Microsoft.AspNetCore.Mvc;

namespace Localiza_Aplicattion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticController : ControllerBase
    {
        
        
        private readonly IAutencticaService _authService;

        public AutenticController(IAutencticaService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistroDTO registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = await _authService.Register(registerDto);

            if (usuario == null)
            {
                return BadRequest(new { Message = "Email já cadastrado." });
            }

            return StatusCode(201, new { Message = "Usuário registrado com sucesso." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogInDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _authService.Login(loginDto);

            if (response == null)
            {
                return Unauthorized(new { Message = "Email ou senha inválidos." });
            }

            return Ok(response);
        }
        
    }
}
