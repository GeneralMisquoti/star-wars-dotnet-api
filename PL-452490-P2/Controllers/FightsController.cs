using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PL_452490_P2.Data;
using PL_452490_P2.Models;

namespace PL_452490_P2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FightsController : ControllerBase
    {
        private readonly MyContext _context;

        public FightsController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Fights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fight>>> GetFights()
        {
            return await _context.Fights.ToListAsync();
        }

        // GET: api/Fights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fight>> GetFight(int id)
        {
            var fight = await _context.Fights.FindAsync(id);

            if (fight == null)
            {
                return NotFound();
            }

            return fight;
        }

        // PUT: api/Fights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFight(int id, Fight fight)
        {
            if (id != fight.Id)
            {
                return BadRequest();
            }

            _context.Entry(fight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FightExists(id))
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

        // POST: api/Fights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fight>> PostFight(Fight fight)
        {
            _context.Fights.Add(fight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFight", new { id = fight.Id }, fight);
        }

        // DELETE: api/Fights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFight(int id)
        {
            var fight = await _context.Fights.FindAsync(id);
            if (fight == null)
            {
                return NotFound();
            }

            _context.Fights.Remove(fight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FightExists(int id)
        {
            return _context.Fights.Any(e => e.Id == id);
        }
    }
}
