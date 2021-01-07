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
    public class BlowsController : ControllerBase
    {
        private readonly MyContext _context;

        public BlowsController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Blows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blow>>> GetBlows()
        {
            return await _context.Blows.ToListAsync();
        }

        // GET: api/Blows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blow>> GetBlow(int id)
        {
            var blow = await _context.Blows.FindAsync(id);

            if (blow == null)
            {
                return NotFound();
            }

            return blow;
        }

        // PUT: api/Blows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlow(int id, Blow blow)
        {
            if (id != blow.Id)
            {
                return BadRequest();
            }

            _context.Entry(blow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlowExists(id))
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

        // POST: api/Blows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Blow>> PostBlow(Blow blow)
        {
            _context.Blows.Add(blow);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlow", new { id = blow.Id }, blow);
        }

        // DELETE: api/Blows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlow(int id)
        {
            var blow = await _context.Blows.FindAsync(id);
            if (blow == null)
            {
                return NotFound();
            }

            _context.Blows.Remove(blow);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlowExists(int id)
        {
            return _context.Blows.Any(e => e.Id == id);
        }
    }
}
