using Microsoft.AspNetCore.Mvc;
using server.Services;
using server.Dtos;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("registrar")]
        public IActionResult RegistrarUsuario([FromBody] UsuarioRegistroDto dto)
        {
            var respuesta = _usuarioService.RegistrarUsuario(dto);
            if (!respuesta.Ok)
            {
                var errorDto = new ErrorResponseDto
                {
                    Ok = false,
                    Mensaje = respuesta.Mensaje
                };
                return BadRequest(errorDto);
            }

            return Ok(respuesta);
        }

        [HttpPost("login")]
        public IActionResult LoginUsuario([FromBody] UsuarioLoginDto dto)
        {
            var respuesta = _usuarioService.LoginUsuario(dto);
            if (!respuesta.Ok)
            {
                var errorDto = new ErrorResponseDto
                {
                    Ok = false,
                    Mensaje = respuesta.Mensaje
                };
                return Unauthorized(errorDto);
            }
            return Ok(respuesta);
        }
    }
}
