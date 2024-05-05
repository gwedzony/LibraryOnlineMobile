using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileAPI.Model;

namespace MobileAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionPreviewController : ControllerBase
    {
        private readonly IdentifierContext _context;

        public CollectionPreviewController(IdentifierContext context)
        {
            _context = context;
        }

        // GET: api/CollectionPreview
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MobileBookCollectionPreview>>> GetMobileBookCollectionPreviews()
        {
            return await _context.MobileBookCollectionPreviews.ToListAsync();
        }

        // GET: api/CollectionPreview/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MobileBookCollectionPreview>> GetMobileBookCollectionPreview(int id)
        {
            var mobileBookCollectionPreview = await _context.MobileBookCollectionPreviews.FindAsync(id);

            if (mobileBookCollectionPreview == null)
            {
                return NotFound();
            }

            return mobileBookCollectionPreview;
        }

        // PUT: api/CollectionPreview/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMobileBookCollectionPreview(int id, MobileBookCollectionPreview mobileBookCollectionPreview)
        {
            if (id != mobileBookCollectionPreview.CollectionPreviewId)
            {
                return BadRequest();
            }

            _context.Entry(mobileBookCollectionPreview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobileBookCollectionPreviewExists(id))
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

        // POST: api/CollectionPreview
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MobileBookCollectionPreview>> PostMobileBookCollectionPreview(MobileBookCollectionPreview mobileBookCollectionPreview)
        {
            _context.MobileBookCollectionPreviews.Add(mobileBookCollectionPreview);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMobileBookCollectionPreview", new { id = mobileBookCollectionPreview.CollectionPreviewId }, mobileBookCollectionPreview);
        }

        // DELETE: api/CollectionPreview/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMobileBookCollectionPreview(int id)
        {
            var mobileBookCollectionPreview = await _context.MobileBookCollectionPreviews.FindAsync(id);
            if (mobileBookCollectionPreview == null)
            {
                return NotFound();
            }

            _context.MobileBookCollectionPreviews.Remove(mobileBookCollectionPreview);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MobileBookCollectionPreviewExists(int id)
        {
            return _context.MobileBookCollectionPreviews.Any(e => e.CollectionPreviewId == id);
        }
    }
}
