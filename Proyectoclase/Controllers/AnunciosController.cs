using Microsoft.AspNetCore.Mvc;
using Proyectoclase.Models;
using Proyectoclase.Services;

namespace Proyectoclase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnunciosController : ControllerBase
    {
        private readonly AnunciosService _anuncioService;

        public AnunciosController(AnunciosService anunciosService)
        {
            _anuncioService = anunciosService;
        }

        // ✅ OBTENER TODOS LOS ANUNCIOS
        [HttpGet]
        public async Task<ActionResult<List<Anuncios>>> ObtenerAnuncios()
        {
            var anuncios = await _anuncioService.ObtenerAnuncios();
            return Ok(anuncios);
        }

        // ✅ OBTENER UN ANUNCIO POR ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Anuncios>> ObtenerAnunciosPorId(Guid id)
        {
            var anuncio = await _anuncioService.ObtenerAnunciosPorId(id);
            if (anuncio == null)
            {
                return NotFound(new { mensaje = "Anuncio no encontrado" });
            }
            return Ok(anuncio);
        }

        // ✅ CREAR UN NUEVO ANUNCIO
        [HttpPost]
        public async Task<ActionResult<Anuncios>> CrearAnuncio([FromBody] Anuncios anuncios)
        {
            // Validar entrada
            if (anuncios == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevoAnuncio = await _anuncioService.CrearAnuncio(anuncios);

            // Devolver 201 Created con la URL del nuevo recurso
            return CreatedAtAction(nameof(ObtenerAnunciosPorId), new { id = nuevoAnuncio.Id }, nuevoAnuncio);
        }

        // ✅ ACTUALIZAR UN ANUNCIO EXISTENTE
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarAnuncio(Guid id, [FromBody] Anuncios anuncioActualizado)
        {
            if (anuncioActualizado == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actualizado = await _anuncioService.ActualizarAnuncio(id, anuncioActualizado);

            if (!actualizado)
            {
                return NotFound(new { mensaje = "Anuncio no encontrado en la base de datos" });
            }

            return NoContent(); // 204 No Content
        }

        // ✅ ELIMINAR UN ANUNCIO
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarAnuncio(Guid id)
        {
            var eliminado = await _anuncioService.EliminarAnuncio(id);
            if (!eliminado)
            {
                return NotFound(new { mensaje = "Anuncio no encontrado en la base de datos" });
            }
            return NoContent();
        }
    }
}
