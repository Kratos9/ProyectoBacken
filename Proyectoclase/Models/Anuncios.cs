using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyectoclase.Models
{
    public class Anuncios
    {
        [Key]
        public Guid Id { get; set; }

        [Column("anuncio")] // Coincide exactamente con la columna en la base de datos
        public string Anuncio { get; set; }

        [Column("persona")]
        public string Persona { get; set; } 

        [Column("motivo")]
        public string Motivo { get; set; } 

        [Column("dni")]
        public string Dni { get; set; } 

        [Column("vehiculo")]
        public string Vehiculo { get; set; } 

        [Column("imagen_url")]
        public string? ImagenUrl { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
