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
    public class LatestMobileBooksAuthorCardController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public LatestMobileBooksAuthorCardController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/LatestMobileBooksAuthorCard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LatestMobileBooksAuthorCard>>> GetLatestMobileBooksAuthorCard()
        {
            return await _context.LatestMobileBooksAuthorCard.ToListAsync();
        }

        // GET: api/LatestMobileBooksAuthorCard/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LatestMobileBooksAuthorCard>> GetLatestMobileBooksAuthorCard(int id)
        {
            var latestMobileBooksAuthorCard = await _context.LatestMobileBooksAuthorCard.FindAsync(id);

            if (latestMobileBooksAuthorCard == null)
            {
                return NotFound();
            }

            return latestMobileBooksAuthorCard;
        }

        // PUT: api/LatestMobileBooksAuthorCard/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLatestMobileBooksAuthorCard(int id, LatestMobileBooksAuthorCard latestMobileBooksAuthorCard)
        {
            if (id != latestMobileBooksAuthorCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(latestMobileBooksAuthorCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LatestMobileBooksAuthorCardExists(id))
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

        // POST: api/LatestMobileBooksAuthorCard
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LatestMobileBooksAuthorCard>> PostLatestMobileBooksAuthorCard(LatestMobileBooksAuthorCard latestMobileBooksAuthorCard)
        {
            _context.LatestMobileBooksAuthorCard.Add(latestMobileBooksAuthorCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLatestMobileBooksAuthorCard", new { id = latestMobileBooksAuthorCard.Id }, latestMobileBooksAuthorCard);
        }

        // DELETE: api/LatestMobileBooksAuthorCard/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLatestMobileBooksAuthorCard(int id)
        {
            var latestMobileBooksAuthorCard = await _context.LatestMobileBooksAuthorCard.FindAsync(id);
            if (latestMobileBooksAuthorCard == null)
            {
                return NotFound();
            }

            _context.LatestMobileBooksAuthorCard.Remove(latestMobileBooksAuthorCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LatestMobileBooksAuthorCardExists(int id)
        {
            return _context.LatestMobileBooksAuthorCard.Any(e => e.Id == id);
        }
    }
}
