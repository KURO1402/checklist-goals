namespace server.Dtos
{
    public class ErrorResponseDto
    {
        public bool Ok { get; set; } = false;
        public string Mensaje { get; set; } = string.Empty;
    }
}
