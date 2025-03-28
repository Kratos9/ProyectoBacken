using Microsoft.EntityFrameworkCore;
using Proyectoclase.Data;
using Proyectoclase.Models;

namespace Proyectoclase.Services
{
    public class AnunciosService
    {
        private readonly DataContext _context;

        public AnunciosService(DataContext context)
        {
            _context = context;
        }

        // ✅ OBTENER TODOS LOS ANUNCIOS
        public async Task<List<Anuncios>> ObtenerAnuncios()
        {
            return await _context.Anuncios.ToListAsync();
        }

        // ✅ OBTENER ANUNCIO POR ID
        public async Task<Anuncios?> ObtenerAnunciosPorId(Guid id)
        {
            return await _context.Anuncios.FindAsync(id);
        }

        // ✅ CREAR ANUNCIO
        public async Task<Anuncios> CrearAnuncio(Anuncios anuncios)
        {
            anuncios.Id = Guid.NewGuid();

            _context.Anuncios.Add(anuncios);
            await _context.SaveChangesAsync();

            return anuncios; // Devolvemos el anuncio creado
        }

        // ✅ ACTUALIZAR ANUNCIO
     
        public async Task<bool> ActualizarAnuncio(Guid id, Anuncios anuncioActualizado)
        {
            var anuncio = await _context.Anuncios.FindAsync(id);
            if (anuncio == null) return false;

            // Actualizamos las propiedades solo si no son nulas
            anuncio.Anuncio = anuncioActualizado.Anuncio ?? anuncio.Anuncio;
            anuncio.Persona = anuncioActualizado.Persona ?? anuncio.Persona;
            anuncio.Motivo = anuncioActualizado.Motivo ?? anuncio.Motivo;
            anuncio.Dni = anuncioActualizado.Dni;
            anuncio.Vehiculo = anuncioActualizado.Vehiculo ?? anuncio.Vehiculo;
            anuncio.ImagenUrl = anuncioActualizado.ImagenUrl ?? anuncio.ImagenUrl;

            await _context.SaveChangesAsync();
            return true;
        }


        // ✅ ELIMINAR ANUNCIO
        public async Task<bool> EliminarAnuncio(Guid id)
        {
            var anuncio = await _context.Anuncios.FindAsync(id);
            if (anuncio == null) return false;

            _context.Anuncios.Remove(anuncio);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
