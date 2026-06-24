using server.Dtos;
namespace server.Services
{
    public interface IUsuarioService
    {
        Task<AuthResponseDto> RegistrarUsuarioAsync(UsuarioRegistroDto dto);

        Task<AuthResponseDto> LoginUsuarioAsync(UsuarioLoginDto dto);
    }
}
