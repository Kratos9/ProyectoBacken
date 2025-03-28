using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyectoclase.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("correo")]
        public string Correo { get; set; }
        [Column("contrasena")]
        public string Contrasena { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
