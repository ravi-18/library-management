using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementApi.Data;
using LibraryManagementApi.Models;
using LibraryManagementApi.Dtos.Book;
using LibraryManagementApi.Interfaces.Services;

namespace LibraryManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        // GET: api/Book
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BookResponseDto>))]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                return Ok(await _bookService.GetAllBooksAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving books.");
                return BadRequest(new { Message = ex.InnerException?.Message ?? ex.Message });
            }
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookResponseDto))]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            try
            {
                var book = await _bookService.GetBookByIdAsync(id);
                if (book == null)
                {
                    return NotFound(new { Message = "Book not found." });
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the book.");
                return BadRequest(new { Message = ex.InnerException?.Message ?? ex.Message });
            }
        }

        // PUT: api/Book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookResponseDto))]
        public async Task<IActionResult> PutBook(Guid id, BookUpdateDto book)
        {
            try
            {
                if (id != book.Id)
                {
                    return BadRequest(new { Message = "Book ID mismatch." });
                }
                var updatedBook = await _bookService.UpdateBookAsync(book);
                return Ok(updatedBook);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the book.");
                return BadRequest(new { Message = ex.InnerException?.Message ?? ex.Message });
            }
        }

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookResponseDto))]
        public async Task<ActionResult<Book>> PostBook(BookRequestDto book)
        {
            try
            {
                var newBook = await _bookService.AddBookAsync(book);
                return Ok(newBook);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the book.");
                return BadRequest(new { Message = ex.InnerException?.Message ?? ex.Message });
            }
        }

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            try
            {
                var book = await _bookService.GetBookByIdAsync(id);
                if (book == null)
                {
                    return NotFound(new { Message = "Book not found." });
                }
                await _bookService.DeleteBookAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the book.");
                return BadRequest(new { Message = ex.InnerException?.Message ?? ex.Message });
            }
        }
    }
}
