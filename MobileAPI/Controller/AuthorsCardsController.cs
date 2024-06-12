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
    public class AuthorsCardsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AuthorsCardsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/LatestMobileBooksAuthorCard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MobileBooksAuthorCard>>> GetLatestMobileBooksAuthorCard()
        {
            return await _context.MobileBooksAuthorCard
                .Include(a =>a.Author)
                .ToListAsync();
        }

        // GET: api/LatestMobileBooksAuthorCard/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MobileBooksAuthorCard>> GetLatestMobileBooksAuthorCard(int id)
        {
            var latestMobileBooksAuthorCard = await _context.MobileBooksAuthorCard.FindAsync(id);

            if (latestMobileBooksAuthorCard == null)
            {
                return NotFound();
            }

            return latestMobileBooksAuthorCard;
        }

        // PUT: api/LatestMobileBooksAuthorCard/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLatestMobileBooksAuthorCard(int id, MobileBooksAuthorCard mobileBooksAuthorCard)
        {
            if (id != mobileBooksAuthorCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(mobileBooksAuthorCard).State = EntityState.Modified;

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
        public async Task<ActionResult<MobileBooksAuthorCard>> PostLatestMobileBooksAuthorCard(MobileBooksAuthorCard mobileBooksAuthorCard)
        {
            _context.MobileBooksAuthorCard.Add(mobileBooksAuthorCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLatestMobileBooksAuthorCard", new { id = mobileBooksAuthorCard.Id }, mobileBooksAuthorCard);
        }

        // DELETE: api/LatestMobileBooksAuthorCard/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLatestMobileBooksAuthorCard(int id)
        {
            var latestMobileBooksAuthorCard = await _context.MobileBooksAuthorCard.FindAsync(id);
            if (latestMobileBooksAuthorCard == null)
            {
                return NotFound();
            }

            _context.MobileBooksAuthorCard.Remove(latestMobileBooksAuthorCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LatestMobileBooksAuthorCardExists(int id)
        {
            return _context.MobileBooksAuthorCard.Any(e => e.Id == id);
        }
    }
}
