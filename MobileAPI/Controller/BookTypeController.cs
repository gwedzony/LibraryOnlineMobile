using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileAPI.Model;

namespace MobileAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTypeController : ControllerBase
    {
        private readonly IdentifierContext _context;

        public BookTypeController(IdentifierContext context)
        {
            _context = context;
        }

        // GET: api/BookType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookType>>> GetBookTypes()
        {
            return await _context.BookTypes.ToListAsync();
        }

        // GET: api/BookType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookType>> GetBookType(int id)
        {
            var bookType = await _context.BookTypes.FindAsync(id);

            if (bookType == null)
            {
                return NotFound();
            }

            return bookType;
        }

        // PUT: api/BookType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookType(int id, BookType bookType)
        {
            if (id != bookType.BookTypeId)
            {
                return BadRequest();
            }

            _context.Entry(bookType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookTypeExists(id))
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

        // POST: api/BookType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookType>> PostBookType(BookType bookType)
        {
            _context.BookTypes.Add(bookType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookType", new { id = bookType.BookTypeId }, bookType);
        }

        // DELETE: api/BookType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookType(int id)
        {
            var bookType = await _context.BookTypes.FindAsync(id);
            if (bookType == null)
            {
                return NotFound();
            }

            _context.BookTypes.Remove(bookType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookTypeExists(int id)
        {
            return _context.BookTypes.Any(e => e.BookTypeId == id);
        }
    }
}
