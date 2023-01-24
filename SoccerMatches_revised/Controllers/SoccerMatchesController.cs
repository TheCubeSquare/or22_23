using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SoccerMatches_revised.Models;

namespace SoccerMatches_revised.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoccerMatchesController : ControllerBase
    {
        private readonly SoccerMatchContext _context;
        private readonly IHostEnvironment _environment;

        public SoccerMatchesController(SoccerMatchContext context, IHostEnvironment hostEnvironment)
        {
            _context = context;
            _environment = hostEnvironment;
        }

        // GET: api/SoccerMatches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetSoccerMatches()
        {
            return await _context.match.ToListAsync();
        }

        // GET: api/SoccerMatches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetSoccerMatch(int id)
        {
            var soccerMatch = await _context.match.FindAsync(id);

            if (soccerMatch == null)
            {
                return NotFound();
            }

            return soccerMatch;
        }

        [HttpGet("{id}/firstteam")]
        public async Task<ActionResult<string>> GetFirstTeam(int id)
        {
            var soccerMatch = await _context.match.FindAsync(id);

            if (soccerMatch == null)
            {
                return NotFound();
            }

            return soccerMatch.first_team;
        }

        [HttpGet("{id}/secondteam")]
        public async Task<ActionResult<string>> GetSecondTeam(int id)
        {
            var soccerMatch = await _context.match.FindAsync(id);

            if (soccerMatch == null)
            {
                return NotFound();
            }

            return soccerMatch.second_team;
        }

        [HttpGet("{id}/stadium")]
        public async Task<ActionResult<string>> GetStadium(int id)
        {
            var soccerMatch = await _context.match.FindAsync(id);

            if (soccerMatch == null)
            {
                return NotFound();
            }

            return soccerMatch.stadium;
        }

        // PUT: api/SoccerMatches/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoccerMatch(int id, Match soccerMatch)
        {
            if (id != soccerMatch.matchid)
            {
                return BadRequest();
            }

            _context.Entry(soccerMatch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoccerMatchExists(id))
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

        // POST: api/SoccerMatches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Match>> PostSoccerMatch(Match soccerMatch)
        {
            _context.match.Add(soccerMatch);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSoccerMatch), new { id = soccerMatch.matchid }, soccerMatch);
        }

        // DELETE: api/SoccerMatches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Match>> DeleteSoccerMatch(int id)
        {
            var soccerMatch = await _context.match.FindAsync(id);
            if (soccerMatch == null)
            {
                return NotFound();
            }

            _context.match.Remove(soccerMatch);
            await _context.SaveChangesAsync();

            return soccerMatch;
        }

        private bool SoccerMatchExists(int id)
        {
            return _context.match.Any(e => e.matchid == id);
        }

        [HttpGet("openapi")]
        public async Task<ActionResult<string>> GetOpenApi()
        {
            return await System.IO.File.ReadAllTextAsync(Path.Combine(_environment.ContentRootPath, "openapi.json"));
        }
    }
}
