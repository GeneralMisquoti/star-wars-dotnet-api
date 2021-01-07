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
    public class FightGroupsController : ControllerBase
    {
        private readonly MyContext _context;

        public FightGroupsController(MyContext context)
        {
            _context = context;
        }

        // GET: api/FightGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FightGroup>>> GetFightGroups()
        {
            return await _context.FightGroups.ToListAsync();
        }

        // GET: api/FightGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FightGroup>> GetFightGroup(int id)
        {
            var fightGroup = await _context.FightGroups.FindAsync(id);

            if (fightGroup == null)
            {
                return NotFound();
            }

            return fightGroup;
        }

        // PUT: api/FightGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFightGroup(int id, FightGroup fightGroup)
        {
            if (id != fightGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(fightGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FightGroupExists(id))
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

        // POST: api/FightGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FightGroup>> PostFightGroup(FightGroup fightGroup)
        {
            _context.FightGroups.Add(fightGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFightGroup", new { id = fightGroup.Id }, fightGroup);
        }

        // DELETE: api/FightGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFightGroup(int id)
        {
            var fightGroup = await _context.FightGroups.FindAsync(id);
            if (fightGroup == null)
            {
                return NotFound();
            }

            _context.FightGroups.Remove(fightGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FightGroupExists(int id)
        {
            return _context.FightGroups.Any(e => e.Id == id);
        }
    }
}
