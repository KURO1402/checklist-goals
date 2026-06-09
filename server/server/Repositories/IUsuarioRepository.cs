using server.Models;

namespace server.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario ? ObtenerUsuarioPorNombre(string NombreUsuario);

        void RegistrarUsuario(Usuario usuario);
    }
}
