using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementApi.Data;
using LibraryManagementApi.Models;

namespace LibraryManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookReservationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BookReservation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReservation>>> GetBookReservation()
        {
            return await _context.BookReservation.ToListAsync();
        }

        // GET: api/BookReservation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookReservation>> GetBookReservation(Guid id)
        {
            var bookReservation = await _context.BookReservation.FindAsync(id);

            if (bookReservation == null)
            {
                return NotFound();
            }

            return bookReservation;
        }

        // PUT: api/BookReservation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookReservation(Guid id, BookReservation bookReservation)
        {
            if (id != bookReservation.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookReservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookReservationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookReservation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookReservation>> PostBookReservation(BookReservation bookReservation)
        {
            _context.BookReservation.Add(bookReservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookReservation", new { id = bookReservation.Id }, bookReservation);
        }

        // DELETE: api/BookReservation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookReservation(Guid id)
        {
            var bookReservation = await _context.BookReservation.FindAsync(id);
            if (bookReservation == null)
            {
                return NotFound();
            }

            _context.BookReservation.Remove(bookReservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookReservationExists(Guid id)
        {
            return _context.BookReservation.Any(e => e.Id == id);
        }
    }
}
