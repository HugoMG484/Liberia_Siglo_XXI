using LibreriaSXXI.Context;
using LibreriaSXXI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibreriaSXXI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly LibreriaSxxiContext _context;

        // Constructor que recibe un contexto de base de datos al ser instanciado
        public AuthorController(LibreriaSxxiContext context)
        {
            _context = context;
        }

        // Método POST: api/Author
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Author author)
        {
            try
            {
                // Verifica si los datos del autor son nulos
                if (author == null)
                {
                    return BadRequest("Datos del autor no proporcionados");
                }

                // Agrega el autor al contexto y guarda los cambios en la base de datos
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();

                // Retorna una respuesta HTTP 201 (Created) con los detalles del autor creado
                return CreatedAtAction(nameof(Get), new { id = author.Id }, author);
            }
            catch (Exception ex)
            {
                // Retorna una respuesta HTTP 400 (BadRequest) con un mensaje de error en caso de excepción
                return BadRequest($"Error al guardar los cambios. Detalles: {ex.Message}");
            }
        }

        // Método GET: api/Author
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Obtiene la lista de autores desde la base de datos de forma asíncrona
                var listAuthor = await _context.Authors.ToListAsync();

                // Retorna una respuesta HTTP 200 (OK) con la lista de autores
                return Ok(listAuthor);
            }
            catch (Exception ex)
            {
                // Retorna una respuesta HTTP 400 (BadRequest) con un mensaje de error en caso de excepción
                return BadRequest(ex.Message);
            }
        }
    }
}
