#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly PokemonContext _context;

        public CardsController(PokemonContext context)
        {
            _context = context;
        }

        // GET: api/Cards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetCards()
        {
            return await _context.Cards.ToListAsync();
        }

        // GET: api/Cards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCard(string id)
        {
            //var card = await _context.Cards.Include(a => a.Attacks).FindAsync(id);

            var card = await _context.Cards.Include(a => a.Attacks).FirstOrDefaultAsync(a => a.id == id);

            if (card == null)
            {
                return NotFound();
            }

            return card;
        }


        // GET: api/Cards/set/5
        [HttpGet("set/{id}")]
        public async Task<ActionResult<IEnumerable<Card>>> GetCardsforSet(string id)
        {
            return await _context.Cards.Where(c => c.setId.Equals(id)).OrderBy(c => c.number).Include(c => c.Attacks).ToListAsync();
        }

        // GET: api/Cards/pokemon/5
        [HttpGet("pokemon/{id}")]
        public async Task<ActionResult<IEnumerable<Card>>> GetCardsforPokemon(int id)
        {
            return await _context.Cards.Where(c => c.pokedexId.Equals(id)).Include(c => c.Attacks).ToListAsync();
        }




        // PUT: api/Cards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCard(string id, Card card)
        //{
        //    if (id != card.id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(card).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CardExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //POST: api/Cards
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Card>> PostCard(Card card)
        {
            _context.Cards.Add(card);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CardExists(card.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCard", new { id = card.id }, card);
        }

        // DELETE: api/Cards/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCard(string id)
        //{
        //    var card = await _context.Cards.FindAsync(id);
        //    if (card == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Cards.Remove(card);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool CardExists(string id)
        {
            return _context.Cards.Any(e => e.id == id);
        }
    }
}
