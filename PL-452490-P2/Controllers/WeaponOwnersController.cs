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
    public class WeaponOwnersController : ControllerBase
    {
        private readonly MyContext _context;

        public WeaponOwnersController(MyContext context)
        {
            _context = context;
        }

        // GET: api/WeaponOwners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeaponOwners>>> GetWeaponOwners()
        {
            return await _context.WeaponOwners.ToListAsync();
        }

        // GET: api/WeaponOwners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeaponOwners>> GetWeaponOwners(int id)
        {
            var weaponOwners = await _context.WeaponOwners.FindAsync(id);

            if (weaponOwners == null)
            {
                return NotFound();
            }

            return weaponOwners;
        }

        // PUT: api/WeaponOwners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeaponOwners(int id, WeaponOwners weaponOwners)
        {
            if (id != weaponOwners.Id)
            {
                return BadRequest();
            }

            _context.Entry(weaponOwners).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeaponOwnersExists(id))
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

        // POST: api/WeaponOwners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeaponOwners>> PostWeaponOwners(WeaponOwners weaponOwners)
        {
            _context.WeaponOwners.Add(weaponOwners);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeaponOwners", new { id = weaponOwners.Id }, weaponOwners);
        }

        // DELETE: api/WeaponOwners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeaponOwners(int id)
        {
            var weaponOwners = await _context.WeaponOwners.FindAsync(id);
            if (weaponOwners == null)
            {
                return NotFound();
            }

            _context.WeaponOwners.Remove(weaponOwners);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeaponOwnersExists(int id)
        {
            return _context.WeaponOwners.Any(e => e.Id == id);
        }
    }
}
