using Library.Application.Abstractions;
using Library.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _svc;

        public BooksController(IBookService svc)
        {
            _svc = svc;
        }

        // GET: api/books/GetAllBooks
        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _svc.GetAllBooks();
            return Ok(books);
        }

        // GET: api/books/GetBookById/5
        [HttpGet("GetBookById/{id:int}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _svc.GetBookById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST: api/books/AddBook
        [HttpPost("AddBook")]
        public async Task<IActionResult> CreateBook(CreatedBookDto dto)
        {
            var id = await _svc.CreateBook(dto);
            return CreatedAtAction(nameof(GetBookById), new { id }, id);
        }

        // PUT: api/books/UpdateBook/5
        [HttpPut("UpdateBook/{id:int}")]
        public async Task<IActionResult> UpdateBook(int id, UpdatedBookDto dto)
        {
            if (id != dto.Id) return BadRequest("Id mismatch");

            await _svc.UpdateBook(dto);
            return NoContent();
        }

        // DELETE: api/books/DeleteBook/5
        [HttpDelete("DeleteBook/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _svc.DeleteBook(id);
            return NoContent();
        }

        // GET: api/books/with-categories (via Stored Procedure)
        [HttpGet("GetAllBooks-with-categories")]
        public async Task<IActionResult> GetWithCategories()
        {
            var rows = await _svc.GetAllWithCategoriesSPAsync();
            return Ok(rows.Select(r => new
            {
                r.BookId,
                r.Title,
                r.Author,
                r.PublishedOn,
                Categories = r.Categories
            }));
        }
    }
}
