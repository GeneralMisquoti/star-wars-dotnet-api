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
    public class LifeFormTypesController : ControllerBase
    {
        private readonly MyContext _context;

        public LifeFormTypesController(MyContext context)
        {
            _context = context;
        }

        // GET: api/LifeFormTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LifeFormType>>> GetLifeFormTypes()
        {
            return await _context.LifeFormTypes.ToListAsync();
        }

        // GET: api/LifeFormTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LifeFormType>> GetLifeFormType(int id)
        {
            var lifeFormType = await _context.LifeFormTypes.FindAsync(id);

            if (lifeFormType == null)
            {
                return NotFound();
            }

            return lifeFormType;
        }

        // PUT: api/LifeFormTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLifeFormType(int id, LifeFormType lifeFormType)
        {
            if (id != lifeFormType.Id)
            {
                return BadRequest();
            }

            _context.Entry(lifeFormType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LifeFormTypeExists(id))
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

        // POST: api/LifeFormTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LifeFormType>> PostLifeFormType(LifeFormType lifeFormType)
        {
            ValueTask<AbstractLifeFormType> abstractLifeFormType = default;
            if (lifeFormType.AbstractLifeFormTypeId.HasValue)
            {
                abstractLifeFormType = _context.AbstractLifeFormTypes.FindAsync(lifeFormType.AbstractLifeFormTypeId);
                if (lifeFormType.AbstractLifeFormType is not null)
                {
                    return BadRequest("Can't have both AbstractLifeFormType and AbstractLifeFormTypeId");
                }
            }
            else
            {
                if (lifeFormType.AbstractLifeFormType is null)
                {
                    return BadRequest("Either AbstractLifeFormType or AbstractLifeFormTypeId required");
                }
            }

            
            // https://stackoverflow.com/questions/65553168/how-to-await-multiple-possibly-uninitialized-tasks-in-c
            await Task.WhenAll(abstractLifeFormType.AsTask());

            if (lifeFormType.AbstractLifeFormTypeId.HasValue)
            {
                if (abstractLifeFormType.Result is null)
                {
                    return BadRequest("AbstractLifeFormTypeId does not exist");
                }
                else
                {
                    lifeFormType.AbstractLifeFormType = abstractLifeFormType.Result;
                }
            }
            _context.LifeFormTypes.Add(lifeFormType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLifeFormType", new { id = lifeFormType.Id }, lifeFormType);
        }

        // DELETE: api/LifeFormTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLifeFormType(int id)
        {
            var lifeFormType = await _context.LifeFormTypes.FindAsync(id);
            if (lifeFormType == null)
            {
                return NotFound();
            }

            _context.LifeFormTypes.Remove(lifeFormType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LifeFormTypeExists(int id)
        {
            return _context.LifeFormTypes.Any(e => e.Id == id);
        }
    }
}
