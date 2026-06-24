namespace server.Dtos
{
    public class ObjetivoCrearDto
    {
        public string NombreObjetivo { get; set; } = string.Empty;
        public string? DescripcionObjetivo { get; set; }
        public int TotalDias { get; set; }
    }
}
