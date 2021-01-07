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
    public class AbstractLifeFormTypesController : ControllerBase
    {
        private readonly MyContext _context;

        public AbstractLifeFormTypesController(MyContext context)
        {
            _context = context;
        }

        // GET: api/AbstractLifeFormTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AbstractLifeFormType>>> GetAbstractLifeFormTypes()
        {
            return await _context.AbstractLifeFormTypes.ToListAsync();
        }

        // GET: api/AbstractLifeFormTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AbstractLifeFormType>> GetAbstractLifeFormType(int id)
        {
            var abstractLifeFormType = await _context.AbstractLifeFormTypes.FindAsync(id);

            if (abstractLifeFormType == null)
            {
                return NotFound();
            }

            return abstractLifeFormType;
        }

        // PUT: api/AbstractLifeFormTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbstractLifeFormType(int id, AbstractLifeFormType abstractLifeFormType)
        {
            if (id != abstractLifeFormType.Id)
            {
                return BadRequest();
            }

            _context.Entry(abstractLifeFormType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbstractLifeFormTypeExists(id))
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

        // POST: api/AbstractLifeFormTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AbstractLifeFormType>> PostAbstractLifeFormType(AbstractLifeFormType abstractLifeFormType)
        {
            _context.AbstractLifeFormTypes.Add(abstractLifeFormType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbstractLifeFormType", new { id = abstractLifeFormType.Id }, abstractLifeFormType);
        }

        // DELETE: api/AbstractLifeFormTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbstractLifeFormType(int id)
        {
            var abstractLifeFormType = await _context.AbstractLifeFormTypes.FindAsync(id);
            if (abstractLifeFormType == null)
            {
                return NotFound();
            }

            _context.AbstractLifeFormTypes.Remove(abstractLifeFormType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AbstractLifeFormTypeExists(int id)
        {
            return _context.AbstractLifeFormTypes.Any(e => e.Id == id);
        }
    }
}
