namespace server.Dtos
{
    public class AuthResponseDto
    {
        public bool Ok { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
    }
}
