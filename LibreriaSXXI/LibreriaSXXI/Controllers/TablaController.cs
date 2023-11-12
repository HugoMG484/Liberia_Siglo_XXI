using LibreriaSXXI.Context;
using LibreriaSXXI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibreriaSXXI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablaController : ControllerBase
    {
        private readonly LibreriaSxxiContext _context;

        // Constructor que recibe un contexto de base de datos al ser instanciado
        public TablaController(LibreriaSxxiContext context)
        {
            _context = context;
        }

        // Método GET: api/Tabla
        [HttpGet]
        public async Task<IActionResult> GetLibrosConAutor()
        {
            try
            {
                // Realiza una consulta a la base de datos para obtener la lista de libros con información del autor
                var result = await _context.Books
                    .Include(b => b.Author)  // Incluye la información del autor
                    .Select(b => new Tabla  // Proyecta los resultados a la clase Tabla
                    {
                        Title = b.Title,  // Título del libro
                        AuthorName = b.Author != null ? b.Author.Name : "Desconocido",  // Nombre del autor o "Desconocido" si no hay autor
                        Chapters = b.Chapters,  // Número de capítulos
                        Pages = b.Pages,  // Número de páginas
                        Price = b.Price  // Precio del libro
                    })
                    .ToListAsync();  // Convierte los resultados en una lista

                // Retorna una respuesta HTTP 200 (OK) con la lista de libros y detalles del autor
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Retorna una respuesta HTTP 400 (BadRequest) con un mensaje de error en caso de excepción
                return BadRequest(ex.Message);
            }
        }
    }
}
