using server.Models;

namespace server.Repositories
{
    public interface IObjetivoRepository
    {
        Task<Objetivo> CrearObjetivoAsync(Objetivo objetivo);
        Task<List<Objetivo>> ObtenerObjetivosPorUsuarioAsync(int idUsuario);
    }
}
