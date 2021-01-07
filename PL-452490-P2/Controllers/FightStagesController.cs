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
    public class FightStagesController : ControllerBase
    {
        private readonly MyContext _context;

        public FightStagesController(MyContext context)
        {
            _context = context;
        }

        // GET: api/FightStages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FightStage>>> GetFightStages()
        {
            return await _context.FightStages.ToListAsync();
        }

        // GET: api/FightStages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FightStage>> GetFightStage(int id)
        {
            var fightStage = await _context.FightStages.FindAsync(id);

            if (fightStage == null)
            {
                return NotFound();
            }

            return fightStage;
        }

        // PUT: api/FightStages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFightStage(int id, FightStage fightStage)
        {
            if (id != fightStage.Id)
            {
                return BadRequest();
            }

            _context.Entry(fightStage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FightStageExists(id))
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

        // POST: api/FightStages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FightStage>> PostFightStage(FightStage fightStage)
        {
            _context.FightStages.Add(fightStage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFightStage", new { id = fightStage.Id }, fightStage);
        }

        // DELETE: api/FightStages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFightStage(int id)
        {
            var fightStage = await _context.FightStages.FindAsync(id);
            if (fightStage == null)
            {
                return NotFound();
            }

            _context.FightStages.Remove(fightStage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FightStageExists(int id)
        {
            return _context.FightStages.Any(e => e.Id == id);
        }
    }
}
