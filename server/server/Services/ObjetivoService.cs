using server.Dtos;
using server.Models;
using server.Repositories;

namespace server.Services
{
    public class ObjetivoService : IObjetivoService
    {
        private readonly IObjetivoRepository _objetivoRepository;

        public ObjetivoService(IObjetivoRepository objetivoRepository)
        {
            _objetivoRepository = objetivoRepository;
        }

        public async Task<ObjetivoResponseDto> CrearObjetivoAsync(ObjetivoCrearDto dto, int idUsuario)
        {
            var objetivo = new Objetivo
            {
                NombreObjetivo = dto.NombreObjetivo,
                DescripcionObjetivo = dto.DescripcionObjetivo,
                TotalDias = dto.TotalDias,
                DiasCompletados = 0,
                EstadoObjetivo = "en_progreso",
                FechaCreacion = DateTime.UtcNow,
                IdUsuario = idUsuario
            };

            var creado = await _objetivoRepository.CrearObjetivoAsync(objetivo);

            return MapearARespuesta(creado);
        }

        public async Task<List<ObjetivoResponseDto>> ObtenerObjetivosPorUsuarioAsync(int idUsuario)
        {
            var objetivos = await _objetivoRepository.ObtenerObjetivosPorUsuarioAsync(idUsuario);
            return objetivos.Select(MapearARespuesta).ToList();
        }

        private static ObjetivoResponseDto MapearARespuesta(Objetivo objetivo)
        {
            return new ObjetivoResponseDto
            {
                IdObjetivo = objetivo.IdObjetivo,
                NombreObjetivo = objetivo.NombreObjetivo,
                DescripcionObjetivo = objetivo.DescripcionObjetivo,
                TotalDias = objetivo.TotalDias,
                DiasCompletados = objetivo.DiasCompletados,
                EstadoObjetivo = objetivo.EstadoObjetivo,
                FechaCreacion = objetivo.FechaCreacion,
                FechaCompletado = objetivo.FechaCompletado
            };
        }
    }
}
