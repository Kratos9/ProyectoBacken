
using Microsoft.EntityFrameworkCore;
using Proyectoclase.Models;

namespace Proyectoclase.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Anuncios> Anuncios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeo de la entidad Usuario
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<Usuario>().Property(U => U.Nombre).HasColumnName("nombre");
            modelBuilder.Entity<Usuario>().Property(U => U.Correo).HasColumnName("correo");
            modelBuilder.Entity<Usuario>().Property(U => U.Contrasena).HasColumnName("contrasena");
            modelBuilder.Entity<Usuario>().Property(U => U.CreatedAt).HasColumnName("created_at");

            // Mapeo de la entidad Anuncios
            modelBuilder.Entity<Anuncios>().ToTable("anuncios");
            modelBuilder.Entity<Anuncios>(entity =>
            {
                entity.Property(a => a.Anuncio).HasColumnName("anuncio");
                entity.Property(a => a.Persona).HasColumnName("persona");
                entity.Property(a => a.Motivo).HasColumnName("motivo");
                entity.Property(a => a.Dni).HasColumnName("dni");
                entity.Property(a => a.Vehiculo).HasColumnName("vehiculo");
                entity.Property(a => a.ImagenUrl).HasColumnName("imagen_url");
            });
        }
    }
}
