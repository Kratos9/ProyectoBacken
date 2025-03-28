using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Proyectoclase.Models;
using Proyectoclase.Services;

namespace Proyectoclase.Controllers
{

    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]

    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioSerice _usuarioService;
        

        public UsuariosController(UsuarioSerice usuarioSerice)
        {
            _usuarioService = usuarioSerice;
        }
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> ObtenerUsuarios()
        {
            var usuarios = await _usuarioService.ObtenerUsuarios();
            return Ok(usuarios);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> ObtenerUsuarioPorId(Guid id)
        {
            var usuario = await _usuarioService.ObtenerUsuarioPorId(id);
            if (usuario == null) return NotFound("Usuario no encontrado");

            return Ok(usuario);
        }
        [HttpPost]
        public async Task<ActionResult> CrearUsuario([FromBody]Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Datos de usuarios vienen vacios");
            }
            var nuevoUsuario = await _usuarioService.CrearUsuario(usuario);

            return Ok(usuario);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarUsuario(Guid id, [FromBody]Usuario usuarioActualizado)
        {
            if(usuarioActualizado == null)
            {
                return BadRequest("Datos del usuario vienen vacios");
            }
            
            var response = await _usuarioService.ActualizarUsuario(id, usuarioActualizado);
            if (response == false)
            {
                return NotFound("Usuario no encontrado en la base de datso");

            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarUsuario(Guid id)
        {
            var response = await _usuarioService.EliminarUsuario(id);
            if (response == false)
            {
                return NotFound("Usuario no encontrado en la base de datos");
            }
            return NoContent();
        }
    }
}
