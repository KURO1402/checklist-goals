namespace server.Dtos
{
    public class ObjetivoResponseDto
    {
        public int IdObjetivo { get; set; }
        public string NombreObjetivo { get; set; } = string.Empty;
        public string? DescripcionObjetivo { get; set; }
        public int TotalDias { get; set; }
        public int DiasCompletados { get; set; }
        public string EstadoObjetivo { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaCompletado { get; set; }
    }
}
