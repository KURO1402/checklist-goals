using System.Linq;
using server.Data;
using server.Models;

namespace server.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Usuario? ObtenerUsuarioPorNombre(string NombreUsuario)
        {
            return _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == NombreUsuario);
        }

        public void RegistrarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
    }
}
