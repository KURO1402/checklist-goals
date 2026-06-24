using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Dtos;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ObjetivoController : ControllerBase
    {
        private readonly IObjetivoService _objetivoService;

        public ObjetivoController(IObjetivoService objetivoService)
        {
            _objetivoService = objetivoService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearObjetivo([FromBody] ObjetivoCrearDto dto)
        {
            var idUsuario = ObtenerIdUsuario();
            if (idUsuario == null)
                return Unauthorized(new ErrorResponseDto { Mensaje = "Token inválido." });

            var objetivo = await _objetivoService.CrearObjetivoAsync(dto, idUsuario.Value);
            return CreatedAtAction(nameof(ObtenerObjetivos), objetivo);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerObjetivos()
        {
            var idUsuario = ObtenerIdUsuario();
            if (idUsuario == null)
                return Unauthorized(new ErrorResponseDto { Mensaje = "Token inválido." });

            var objetivos = await _objetivoService.ObtenerObjetivosPorUsuarioAsync(idUsuario.Value);
            return Ok(objetivos);
        }

        private int? ObtenerIdUsuario()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null || !int.TryParse(claim.Value, out var id))
                return null;
            return id;
        }
    }
}
