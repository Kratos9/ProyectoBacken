using Microsoft.EntityFrameworkCore;
using Proyectoclase.Data;
using Proyectoclase.Models;

namespace Proyectoclase.Services
{
    public class UsuarioSerice
    {
        private readonly DataContext _context;

        public UsuarioSerice(DataContext context)
        {
            _context = context;
        }

        //obtener todos los usuarios
        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }
        //obtener usuario por ID
        public async Task<Usuario?> ObtenerUsuarioPorId(Guid id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

        }

        // CREAR usuario
        public async Task<Usuario> CrearUsuario(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();
            usuario.CreatedAt = DateTime.UtcNow;

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;

        }

        //actualizar usuario
        public async Task<bool> ActualizarUsuario(Guid id, Usuario usuarioActualizado)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if(usuario == null) return false;

            usuario.Nombre = usuarioActualizado.Nombre;
            usuario.Correo = usuarioActualizado.Correo;
            usuario.Contrasena = usuarioActualizado.Contrasena;

            await _context.SaveChangesAsync();
            return true;
        }
        // eliminar usuario
        public async Task<bool> EliminarUsuario(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}