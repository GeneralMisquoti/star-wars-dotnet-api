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
    public class ActorsPerMoviesController : ControllerBase
    {
        private readonly MyContext _context;

        public ActorsPerMoviesController(MyContext context)
        {
            _context = context;
        }

        // GET: api/ActorSPerMovies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorPerMovie>>> GetActorsPerMovies()
        {
            return await _context.ActorsPerMovies.ToListAsync();
        }

        // GET: api/ActorsPerMovies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActorPerMovie>> GetActorPerMovie(int id)
        {
            var actorPerMovie = await _context.ActorsPerMovies.FindAsync(id);

            if (actorPerMovie == null)
            {
                return NotFound();
            }

            return actorPerMovie;
        }

        // PUT: api/ActorsPerMovies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActorPerMovie(int id, ActorPerMovie actorPerMovie)
        {
            if (id != actorPerMovie.Id)
            {
                return BadRequest();
            }

            _context.Entry(actorPerMovie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorPerMovieExists(id))
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

        // POST: api/ActorsPerMovies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActorPerMovie>> PostActorPerMovie(ActorPerMovie actorPerMovie)
        {
            _context.ActorsPerMovies.Add(actorPerMovie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActorPerMovie", new { id = actorPerMovie.Id }, actorPerMovie);
        }

        // DELETE: api/ActorsPerMovies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActorPerMovie(int id)
        {
            var actorPerMovie = await _context.ActorsPerMovies.FindAsync(id);
            if (actorPerMovie == null)
            {
                return NotFound();
            }

            _context.ActorsPerMovies.Remove(actorPerMovie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActorPerMovieExists(int id)
        {
            return _context.ActorsPerMovies.Any(e => e.Id == id);
        }
    }
}
