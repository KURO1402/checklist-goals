using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using server.Dtos;
using server.Models;
using server.Repositories;

namespace server.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;

        public UsuarioService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }

        public async Task<AuthResponseDto> RegistrarUsuarioAsync(UsuarioRegistroDto dto)
        {
            var usuarioExistente = await _usuarioRepository.ObtenerUsuarioPorNombreAsync(dto.NombreUsuario);
            if (usuarioExistente != null)
            {
                return new AuthResponseDto { Ok = false, Mensaje = "El nombre de usuario ya está en uso." };
            }

            string claveEncriptada = BCrypt.Net.BCrypt.HashPassword(dto.Clave);

            var nuevoUsuario = new Usuario
            {
                NombreUsuario = dto.NombreUsuario,
                ClaveHash = claveEncriptada
            };

            await _usuarioRepository.RegistrarUsuarioAsync(nuevoUsuario);

            string token = GenerarJwtToken(nuevoUsuario);

            return new AuthResponseDto
            {
                Ok = true,
                Mensaje = "Usuario registrado exitosamente.",
                Token = token,
                NombreUsuario = nuevoUsuario.NombreUsuario
            };
        }

        public async Task<AuthResponseDto> LoginUsuarioAsync(UsuarioLoginDto dto)
        {
            var usuario = await _usuarioRepository.ObtenerUsuarioPorNombreAsync(dto.NombreUsuario);
            if (usuario == null)
            {
                return new AuthResponseDto { Ok = false, Mensaje = "Usuario o clave incorrectos." };
            }

            bool claveValida = BCrypt.Net.BCrypt.Verify(dto.Clave, usuario.ClaveHash);
            if (!claveValida)
            {
                return new AuthResponseDto { Ok = false, Mensaje = "Usuario o clave incorrectos." };
            }

            string token = GenerarJwtToken(usuario);

            return new AuthResponseDto
            {
                Ok = true,
                Mensaje = "Inicio de sesión exitoso.",
                Token = token,
                NombreUsuario = usuario.NombreUsuario
            };
        }

        // Método privado para fabricar el JWT
        private string GenerarJwtToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.NombreUsuario)
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}