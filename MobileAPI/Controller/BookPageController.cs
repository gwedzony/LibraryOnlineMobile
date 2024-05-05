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
    public class BookPageController : ControllerBase
    {
        private readonly IdentifierContext _context;

        public BookPageController(IdentifierContext context)
        {
            _context = context;
        }

        // GET: api/BookPage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MobileBookPage>>> GetMobileBookPages()
        {
            return await _context.MobileBookPages.ToListAsync();
        }

        // GET: api/BookPage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MobileBookPage>> GetMobileBookPage(int id)
        {
            var mobileBookPage = await _context.MobileBookPages.FindAsync(id);

            if (mobileBookPage == null)
            {
                return NotFound();
            }

            return mobileBookPage;
        }

        // PUT: api/BookPage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMobileBookPage(int id, MobileBookPage mobileBookPage)
        {
            if (id != mobileBookPage.MobileBookPageId)
            {
                return BadRequest();
            }

            _context.Entry(mobileBookPage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobileBookPageExists(id))
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

        // POST: api/BookPage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MobileBookPage>> PostMobileBookPage(MobileBookPage mobileBookPage)
        {
            _context.MobileBookPages.Add(mobileBookPage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMobileBookPage", new { id = mobileBookPage.MobileBookPageId }, mobileBookPage);
        }

        // DELETE: api/BookPage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMobileBookPage(int id)
        {
            var mobileBookPage = await _context.MobileBookPages.FindAsync(id);
            if (mobileBookPage == null)
            {
                return NotFound();
            }

            _context.MobileBookPages.Remove(mobileBookPage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MobileBookPageExists(int id)
        {
            return _context.MobileBookPages.Any(e => e.MobileBookPageId == id);
        }
    }
}
