using server.Models;

namespace server.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> ObtenerUsuarioPorNombreAsync(string NombreUsuario);

        Task RegistrarUsuarioAsync(Usuario usuario);
    }
}