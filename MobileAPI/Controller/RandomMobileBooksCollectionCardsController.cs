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
    public class RandomMobileBooksCollectionCardsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public RandomMobileBooksCollectionCardsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/RandomMobileBooksCollectionCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RandomMobileBooksCollectionCard>>> GetRandomMobileBooksCollectionCards()
        {
            return await _context.RandomMobileBooksCollectionCards.ToListAsync();
        }

        // GET: api/RandomMobileBooksCollectionCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RandomMobileBooksCollectionCard>> GetRandomMobileBooksCollectionCard(int id)
        {
            var randomMobileBooksCollectionCard = await _context.RandomMobileBooksCollectionCards.FindAsync(id);

            if (randomMobileBooksCollectionCard == null)
            {
                return NotFound();
            }

            return randomMobileBooksCollectionCard;
        }

        // PUT: api/RandomMobileBooksCollectionCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRandomMobileBooksCollectionCard(int id, RandomMobileBooksCollectionCard randomMobileBooksCollectionCard)
        {
            if (id != randomMobileBooksCollectionCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(randomMobileBooksCollectionCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RandomMobileBooksCollectionCardExists(id))
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

        // POST: api/RandomMobileBooksCollectionCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RandomMobileBooksCollectionCard>> PostRandomMobileBooksCollectionCard(RandomMobileBooksCollectionCard randomMobileBooksCollectionCard)
        {
            _context.RandomMobileBooksCollectionCards.Add(randomMobileBooksCollectionCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRandomMobileBooksCollectionCard", new { id = randomMobileBooksCollectionCard.Id }, randomMobileBooksCollectionCard);
        }

        // DELETE: api/RandomMobileBooksCollectionCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRandomMobileBooksCollectionCard(int id)
        {
            var randomMobileBooksCollectionCard = await _context.RandomMobileBooksCollectionCards.FindAsync(id);
            if (randomMobileBooksCollectionCard == null)
            {
                return NotFound();
            }

            _context.RandomMobileBooksCollectionCards.Remove(randomMobileBooksCollectionCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RandomMobileBooksCollectionCardExists(int id)
        {
            return _context.RandomMobileBooksCollectionCards.Any(e => e.Id == id);
        }
    }
}
