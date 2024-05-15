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
    public class DetailsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public DetailsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailBookMobilePage>>> GetDetailBookMobilePages()
        {
            return await _context.DetailBookMobilePages
                .Include(d => d.Book)
                .ThenInclude(b => b.Author)
                .Include(b=>b.Book)
                .ThenInclude(b=>b.BookGenre)
                .ToListAsync();
        }

        // GET: api/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetailBookMobilePage>> GetDetailBookMobilePage(int id)
        {
            var detailBookMobilePage = await _context.DetailBookMobilePages.FindAsync(id);

            if (detailBookMobilePage == null)
            {
                return NotFound();
            }

            return detailBookMobilePage;
        }

        // PUT: api/Details/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetailBookMobilePage(int id, DetailBookMobilePage detailBookMobilePage)
        {
            if (id != detailBookMobilePage.Id)
            {
                return BadRequest();
            }

            _context.Entry(detailBookMobilePage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailBookMobilePageExists(id))
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

        // POST: api/Details
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetailBookMobilePage>> PostDetailBookMobilePage(DetailBookMobilePage detailBookMobilePage)
        {
            _context.DetailBookMobilePages.Add(detailBookMobilePage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetailBookMobilePage", new { id = detailBookMobilePage.Id }, detailBookMobilePage);
        }

        // DELETE: api/Details/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetailBookMobilePage(int id)
        {
            var detailBookMobilePage = await _context.DetailBookMobilePages.FindAsync(id);
            if (detailBookMobilePage == null)
            {
                return NotFound();
            }

            _context.DetailBookMobilePages.Remove(detailBookMobilePage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetailBookMobilePageExists(int id)
        {
            return _context.DetailBookMobilePages.Any(e => e.Id == id);
        }
    }
}
