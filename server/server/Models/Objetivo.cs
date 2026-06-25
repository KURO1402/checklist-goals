using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    [Table("objetivos")]
    public class Objetivo
    {
        [Column("id_objetivo")]
        public int Id { get; set; }
        [Column("nombre_objetivo")]
        public string NombreObjetivo { get; set; } = string.Empty;
        [Column("descripcion_objetivo")]
        public string? DescripcionObjetivo { get; set; } = string.Empty;
        [Column("total_dias")]
        public int TotalDias { get; set; }
        [Column("dias_cumplidos")]
        public int DiasCompletados { get; set; }
        [Column("estado")]
        public string EstadoObjetivo { get; set; } = string.Empty;
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }
        [Column("fecha_completado")]
        public DateTime? FechaCompletado { get; set; }
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
    }
}
