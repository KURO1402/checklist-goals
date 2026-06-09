using server.Dtos;
namespace server.Services
{
    public interface IUsuarioService
    {
        AuthResponseDto RegistrarUsuario(UsuarioRegistroDto dto);

        AuthResponseDto LoginUsuario(UsuarioLoginDto dto);
    }
}
