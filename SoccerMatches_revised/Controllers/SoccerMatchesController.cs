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
        public async Task<ActionResult<IEnumerable<SoccerMatch>>> GetSoccerMatches()
        {
            return await _context.SoccerMatches.ToListAsync();
        }

        // GET: api/SoccerMatches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SoccerMatch>> GetSoccerMatch(int id)
        {
            var soccerMatch = await _context.SoccerMatches.FindAsync(id);

            if (soccerMatch == null)
            {
                return NotFound();
            }

            return soccerMatch;
        }

        [HttpGet("{id}/firstteam")]
        public async Task<ActionResult<string>> GetFirstTeam(int id)
        {
            var soccerMatch = await _context.SoccerMatches.FindAsync(id);

            if (soccerMatch == null)
            {
                return NotFound();
            }

            return soccerMatch.FirstTeam;
        }

        [HttpGet("{id}/secondteam")]
        public async Task<ActionResult<string>> GetSecondTeam(int id)
        {
            var soccerMatch = await _context.SoccerMatches.FindAsync(id);

            if (soccerMatch == null)
            {
                return NotFound();
            }

            return soccerMatch.SecondTeam;
        }

        [HttpGet("{id}/stadium")]
        public async Task<ActionResult<string>> GetStadium(int id)
        {
            var soccerMatch = await _context.SoccerMatches.FindAsync(id);

            if (soccerMatch == null)
            {
                return NotFound();
            }

            return soccerMatch.Stadium;
        }

        // PUT: api/SoccerMatches/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoccerMatch(int id, SoccerMatch soccerMatch)
        {
            if (id != soccerMatch.Id)
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
        public async Task<ActionResult<SoccerMatch>> PostSoccerMatch(SoccerMatch soccerMatch)
        {
            _context.SoccerMatches.Add(soccerMatch);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSoccerMatch), new { id = soccerMatch.Id }, soccerMatch);
        }

        // DELETE: api/SoccerMatches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SoccerMatch>> DeleteSoccerMatch(int id)
        {
            var soccerMatch = await _context.SoccerMatches.FindAsync(id);
            if (soccerMatch == null)
            {
                return NotFound();
            }

            _context.SoccerMatches.Remove(soccerMatch);
            await _context.SaveChangesAsync();

            return soccerMatch;
        }

        private bool SoccerMatchExists(int id)
        {
            return _context.SoccerMatches.Any(e => e.Id == id);
        }

        [HttpGet("openapi")]
        public async Task<ActionResult<string>> GetOpenApi()
        {
            return await System.IO.File.ReadAllTextAsync(Path.Combine(_environment.ContentRootPath, "openapi.json"));
        }
    }
}
