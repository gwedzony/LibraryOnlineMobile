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
    public class BookPreviewController : ControllerBase
    {
        private readonly IdentifierContext _context;

        public BookPreviewController(IdentifierContext context)
        {
            _context = context;
        }

        // GET: api/BookPreview
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MobileBookPreview>>> GetMobileBookPreviews()
        {
            return await _context.MobileBookPreviews.ToListAsync();
        }

        // GET: api/BookPreview/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MobileBookPreview>> GetMobileBookPreview(int id)
        {
            var mobileBookPreview = await _context.MobileBookPreviews.FindAsync(id);

            if (mobileBookPreview == null)
            {
                return NotFound();
            }

            return mobileBookPreview;
        }

        // PUT: api/BookPreview/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMobileBookPreview(int id, MobileBookPreview mobileBookPreview)
        {
            if (id != mobileBookPreview.MobileBookPreviewId)
            {
                return BadRequest();
            }

            _context.Entry(mobileBookPreview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobileBookPreviewExists(id))
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

        // POST: api/BookPreview
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MobileBookPreview>> PostMobileBookPreview(MobileBookPreview mobileBookPreview)
        {
            _context.MobileBookPreviews.Add(mobileBookPreview);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMobileBookPreview", new { id = mobileBookPreview.MobileBookPreviewId }, mobileBookPreview);
        }

        // DELETE: api/BookPreview/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMobileBookPreview(int id)
        {
            var mobileBookPreview = await _context.MobileBookPreviews.FindAsync(id);
            if (mobileBookPreview == null)
            {
                return NotFound();
            }

            _context.MobileBookPreviews.Remove(mobileBookPreview);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MobileBookPreviewExists(int id)
        {
            return _context.MobileBookPreviews.Any(e => e.MobileBookPreviewId == id);
        }
    }
}
