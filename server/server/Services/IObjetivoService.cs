using server.Dtos;

namespace server.Services
{
    public interface IObjetivoService
    {
        Task<ObjetivoResponseDto> CrearObjetivoAsync(ObjetivoCrearDto dto, int idUsuario);
        Task<List<ObjetivoResponseDto>> ObtenerObjetivosPorUsuarioAsync(int idUsuario);
    }
}
