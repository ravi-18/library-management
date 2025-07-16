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
    public class FineController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Fine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fine>>> GetFines()
        {
            return await _context.Fines.ToListAsync();
        }

        // GET: api/Fine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fine>> GetFine(Guid id)
        {
            var fine = await _context.Fines.FindAsync(id);

            if (fine == null)
            {
                return NotFound();
            }

            return fine;
        }

        // PUT: api/Fine/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFine(Guid id, Fine fine)
        {
            if (id != fine.Id)
            {
                return BadRequest();
            }

            _context.Entry(fine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FineExists(id))
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

        // POST: api/Fine
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fine>> PostFine(Fine fine)
        {
            _context.Fines.Add(fine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFine", new { id = fine.Id }, fine);
        }

        // DELETE: api/Fine/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFine(Guid id)
        {
            var fine = await _context.Fines.FindAsync(id);
            if (fine == null)
            {
                return NotFound();
            }

            _context.Fines.Remove(fine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FineExists(Guid id)
        {
            return _context.Fines.Any(e => e.Id == id);
        }
    }
}
