using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    [Table("usuarios")]
    public class Usuario
    {

        [Column("IdUsuario")]
        public int Id { get; set; }
        [Column("NombreUsuario")]
        public string NombreUsuario { get; set; } = string.Empty;
        [Column("ClaveUsuario")]
        public string ClaveHash { get; set; } = string.Empty;
    }
}
