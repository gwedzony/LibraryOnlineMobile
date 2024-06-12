using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Context;
using Database.Data.MobileApp;

namespace MobileAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookcaseController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BookcaseController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Bookcase
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookcase>>> GetBookcases()
        {
            return await _context.Bookcases.Include(b=>b.Books).ToListAsync();
        }

        // GET: api/Bookcase/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bookcase>> GetBookcase(int id)
        {
            var bookcase = await _context.Bookcases.FindAsync(id);

            if (bookcase == null)
            {
                return NotFound();
            }

            return bookcase;
        }

        // PUT: api/Bookcase/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookcase(int id, Bookcase bookcase)
        {
            if (id != bookcase.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookcase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookcaseExists(id))
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

        // POST: api/Bookcase
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bookcase>> PostBookcase(Bookcase bookcase)
        {
            _context.Bookcases.Add(bookcase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookcase", new { id = bookcase.Id }, bookcase);
        }

        // DELETE: api/Bookcase/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookcase(int id)
        {
            var bookcase = await _context.Bookcases.FindAsync(id);
            if (bookcase == null)
            {
                return NotFound();
            }

            _context.Bookcases.Remove(bookcase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookcaseExists(int id)
        {
            return _context.Bookcases.Any(e => e.Id == id);
        }
    }
}
