#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.DTO;
using PokemonAPI.Models;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonContext _context;
        private readonly IMapper _mapper;

        public PokemonController(PokemonContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Pokemon
        [HttpGet]
        public async Task<IActionResult> GetPokemon()
        {
            var Pokemon = await _context.Pokemon.OrderBy(p => p.id).Include(c => c.PokemonRegions).ThenInclude(cs => cs.Region).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<PokemonDTO>>(Pokemon));
        }

        // GET: api/Pokemon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> GetPokemon(int? id)
        {
            var pokemon = await _context.Pokemon.FindAsync(id);

            if (pokemon == null)
            {
                return NotFound();
            }

            return pokemon;
        }

        // PUT: api/Pokemon/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPokemon(int? id, Pokemon pokemon)
        //{
        //    if (id != pokemon.id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(pokemon).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PokemonExists(id))
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

        // POST: api/Pokemon
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Pokemon>> PostPokemon(Pokemon pokemon)
        //{
        //    _context.Pokemon.Add(pokemon);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPokemon", new { id = pokemon.id }, pokemon);
        //}

        // DELETE: api/Pokemon/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePokemon(int? id)
        //{
        //    var pokemon = await _context.Pokemon.FindAsync(id);
        //    if (pokemon == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Pokemon.Remove(pokemon);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool PokemonExists(int? id)
        {
            return _context.Pokemon.Any(e => e.id == id);
        }
    }
}
