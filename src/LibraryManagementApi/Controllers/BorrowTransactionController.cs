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
    public class BorrowTransactionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BorrowTransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BorrowTransaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BorrowTransaction>>> GetBorrowTransactions()
        {
            return await _context.BorrowTransactions.ToListAsync();
        }

        // GET: api/BorrowTransaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowTransaction>> GetBorrowTransaction(Guid id)
        {
            var borrowTransaction = await _context.BorrowTransactions.FindAsync(id);

            if (borrowTransaction == null)
            {
                return NotFound();
            }

            return borrowTransaction;
        }

        // PUT: api/BorrowTransaction/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBorrowTransaction(Guid id, BorrowTransaction borrowTransaction)
        {
            if (id != borrowTransaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(borrowTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowTransactionExists(id))
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

        // POST: api/BorrowTransaction
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BorrowTransaction>> PostBorrowTransaction(BorrowTransaction borrowTransaction)
        {
            _context.BorrowTransactions.Add(borrowTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBorrowTransaction", new { id = borrowTransaction.Id }, borrowTransaction);
        }

        // DELETE: api/BorrowTransaction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrowTransaction(Guid id)
        {
            var borrowTransaction = await _context.BorrowTransactions.FindAsync(id);
            if (borrowTransaction == null)
            {
                return NotFound();
            }

            _context.BorrowTransactions.Remove(borrowTransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BorrowTransactionExists(Guid id)
        {
            return _context.BorrowTransactions.Any(e => e.Id == id);
        }
    }
}
