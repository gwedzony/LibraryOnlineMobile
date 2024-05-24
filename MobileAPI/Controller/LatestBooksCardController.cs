using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Context;
using Database.Data.MobileApp;

namespace MobileAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LatestBooksCardController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public LatestBooksCardController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/LatestBooksCard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LatestMobileBooksCard>>> GetLatestMobileBooksCard()
        {
            return await _context.LatestMobileBooksCard
                .Include(b=>b.Book)
                .ThenInclude(a=>a.Author)
                .ToListAsync();
        }

        // GET: api/LatestBooksCard/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LatestMobileBooksCard>> GetLatestMobileBooksCard(int id)
        {
            var latestMobileBooksCard = await _context.LatestMobileBooksCard.FindAsync(id);

            if (latestMobileBooksCard == null)
            {
                return NotFound();
            }

            return latestMobileBooksCard;
        }

        // PUT: api/LatestBooksCard/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLatestMobileBooksCard(int id, LatestMobileBooksCard latestMobileBooksCard)
        {
            if (id != latestMobileBooksCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(latestMobileBooksCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LatestMobileBooksCardExists(id))
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

        // POST: api/LatestBooksCard
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LatestMobileBooksCard>> PostLatestMobileBooksCard(LatestMobileBooksCard latestMobileBooksCard)
        {
            _context.LatestMobileBooksCard.Add(latestMobileBooksCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLatestMobileBooksCard", new { id = latestMobileBooksCard.Id }, latestMobileBooksCard);
        }

        // DELETE: api/LatestBooksCard/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLatestMobileBooksCard(int id)
        {
            var latestMobileBooksCard = await _context.LatestMobileBooksCard.FindAsync(id);
            if (latestMobileBooksCard == null)
            {
                return NotFound();
            }

            _context.LatestMobileBooksCard.Remove(latestMobileBooksCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LatestMobileBooksCardExists(int id)
        {
            return _context.LatestMobileBooksCard.Any(e => e.Id == id);
        }
    }
}
