using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class PersonController : ControllerBase
    {
        private readonly MyContext _context;

        public PersonController(MyContext context)
        {
            _context = context;
        }

        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople([FromQuery] int? page = 1,
            [FromQuery] int? size = 10)
        {
            List<Person> people = default;
            if (page.HasValue && size.HasValue)
            {
                if (page <= 0 || size <= 0)
                {
                    return BadRequest("page or size invalid");
                }

                people = await _context.People.Skip((page.Value - 1) * size.Value).Take(size.Value).ToListAsync();
            }
            else
            {
                people = await _context.People.ToListAsync();
            }

            foreach (var person in people)
            {
                person.Master = null;
                person.Apprentice = null;
            }

            return people;
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            person.Apprentice = null;
            person.Master = null;

            return person;
        }

        // PUT: api/Person/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/Person
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            ValueTask<Person> master = default, apprentice = default;
            ValueTask<Planet> planet = default;
            ValueTask<LifeFormType> lifeFormType = default;
            if (person.MasterId.HasValue)
            {
                master = _context.People.FindAsync(person.MasterId);
            }

            if (person.ApprenticeId.HasValue)
            {
                apprentice = _context.People.FindAsync(person.ApprenticeId);
            }

            if (person.FromPlanetId.HasValue)
            {
                planet = _context.Planets.FindAsync(person.FromPlanetId);
            }

            if (person.LfTypeId.HasValue)
            {
                lifeFormType = _context.LifeFormTypes.FindAsync(person.LfTypeId);
            }

            // https://stackoverflow.com/questions/65553168/how-to-await-multiple-possibly-uninitialized-tasks-in-c
            await Task.WhenAll(master.AsTask(), apprentice.AsTask(), planet.AsTask(), lifeFormType.AsTask());

            if (person.MasterId.HasValue)
            {
                if (master.Result is null)
                {
                    return BadRequest("MasterId does not exist");
                }
                else
                {
                    person.Master = master.Result;
                }
            }

            if (person.ApprenticeId.HasValue)
            {
                if (apprentice.Result is null)
                {
                    return BadRequest("ApprenticeId does not exist");
                }
                else
                {
                    person.Apprentice = apprentice.Result;
                }
            }

            if (person.FromPlanetId.HasValue)
            {
                if (planet.Result is null)
                {
                    return BadRequest("FromPlanetId does not exist");
                }
                else
                {
                    person.FromPlanet = planet.Result;
                }
            }

            if (person.LfTypeId.HasValue)
            {
                if (lifeFormType.Result is null)
                {
                    return BadRequest("LFTypeId does not exist");
                }
                else
                {
                    person.LfType = lifeFormType.Result;
                }
            }

            _context.People.Add(person);
            await _context.SaveChangesAsync();
            person.Apprentice = null;
            person.Master = null;

            return CreatedAtAction("GetPerson", new {id = person.Id}, person);
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}