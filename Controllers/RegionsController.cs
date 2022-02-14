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
    public class RegionsController : ControllerBase
    {
        private readonly PokemonContext _context;
        private readonly IMapper _mapper;

        public RegionsController(PokemonContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Regions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
        {
            return await _context.Regions.ToListAsync();
        }

        // GET: api/Regions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetRegion(int id)
        {

            var region = await _context.Regions.Where(a => a.id == id).Include(c => c.PokemonRegions).ThenInclude(cs => cs.Pokemon).ToListAsync(); ;

            if (region == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<RegionPokemonDTO>>(region));
        }


        private bool RegionExists(int id)
        {
            return _context.Regions.Any(e => e.id == id);
        }
    }
}
