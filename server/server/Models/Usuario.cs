using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    [Table("usuarios")]
    public class Usuario
    {

        [Column("id_usuario")]
        public int Id { get; set; }
        [Column("nombre_usuario")]
        public string NombreUsuario { get; set; } = string.Empty;
        [Column("clave_usuario")]
        public string ClaveHash { get; set; } = string.Empty;
    }
}
