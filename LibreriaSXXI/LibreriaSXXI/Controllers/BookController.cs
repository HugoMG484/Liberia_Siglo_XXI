using LibreriaSXXI.Context;
using LibreriaSXXI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibreriaSXXI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibreriaSxxiContext _context;

        // Constructor que recibe un contexto de base de datos al ser instanciado
        public BookController(LibreriaSxxiContext context)
        {
            _context = context;
        }

        // Método POST: api/Book
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            try
            {
                // Verifica si los datos del libro son nulos
                if (book == null)
                {
                    return BadRequest("Datos del libro no proporcionados");
                }

                // Verifica si el autor especificado existe en la base de datos
                var authorExists = await _context.Authors.AnyAsync(a => a.Id == book.AuthorId);
                if (!authorExists)
                {
                    return BadRequest("El autor especificado no existe");
                }

                // Agrega el libro al contexto y guarda los cambios en la base de datos
                _context.Books.Add(book);
                await _context.SaveChangesAsync();

                // Retorna una respuesta HTTP 201 (Created) con los detalles del libro creado
                return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                // Retorna una respuesta HTTP 400 (BadRequest) con un mensaje de error en caso de excepción
                return BadRequest($"Error al guardar los cambios. Detalles: {ex.InnerException?.Message}");
            }
        }

        // Método GET: api/Book
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Obtiene la lista de libros desde la base de datos de forma asíncrona
                var listBook = await _context.Books.ToListAsync();

                // Retorna una respuesta HTTP 200 (OK) con la lista de libros
                return Ok(listBook);
            }
            catch (Exception ex)
            {
                // Retorna una respuesta HTTP 400 (BadRequest) con un mensaje de error en caso de excepción
                return BadRequest(ex.Message);
            }
        }

        // Método GET: api/Book/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                // Busca un libro por su ID en la base de datos
                var book = await _context.Books.FindAsync(id);

                // Si el libro no se encuentra, retorna una respuesta HTTP 404 (Not Found)
                if (book == null)
                {
                    return NotFound();
                }

                // Retorna una respuesta HTTP 200 (OK) con los detalles del libro
                return Ok(book);
            }
            catch (Exception ex)
            {
                // Retorna una respuesta HTTP 400 (BadRequest) con un mensaje de error en caso de excepción
                return BadRequest(ex.Message);
            }
        }
    }
}
