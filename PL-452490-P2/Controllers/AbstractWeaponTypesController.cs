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
    public class AbstractWeaponTypesController : ControllerBase
    {
        private readonly MyContext _context;

        public AbstractWeaponTypesController(MyContext context)
        {
            _context = context;
        }

        // GET: api/AbstractWeaponTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AbstractWeaponType>>> GetAbstractWeaponTypes()
        {
            return await _context.AbstractWeaponTypes.ToListAsync();
        }

        // GET: api/AbstractWeaponTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AbstractWeaponType>> GetAbstractWeaponType(int id)
        {
            var abstractWeaponType = await _context.AbstractWeaponTypes.FindAsync(id);

            if (abstractWeaponType == null)
            {
                return NotFound();
            }

            return abstractWeaponType;
        }

        // PUT: api/AbstractWeaponTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbstractWeaponType(int id, AbstractWeaponType abstractWeaponType)
        {
            if (id != abstractWeaponType.Id)
            {
                return BadRequest();
            }

            _context.Entry(abstractWeaponType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbstractWeaponTypeExists(id))
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

        // POST: api/AbstractWeaponTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AbstractWeaponType>> PostAbstractWeaponType(AbstractWeaponType abstractWeaponType)
        {
            _context.AbstractWeaponTypes.Add(abstractWeaponType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbstractWeaponType", new { id = abstractWeaponType.Id }, abstractWeaponType);
        }

        // DELETE: api/AbstractWeaponTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbstractWeaponType(int id)
        {
            var abstractWeaponType = await _context.AbstractWeaponTypes.FindAsync(id);
            if (abstractWeaponType == null)
            {
                return NotFound();
            }

            _context.AbstractWeaponTypes.Remove(abstractWeaponType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AbstractWeaponTypeExists(int id)
        {
            return _context.AbstractWeaponTypes.Any(e => e.Id == id);
        }
    }
}
