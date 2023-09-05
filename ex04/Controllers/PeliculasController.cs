using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ex04.Data;
using ex04.Models;

namespace ex04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PeliculasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Peliculas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pelicula>>> Getpeliculas()
        {
          if (_context.peliculas == null)
          {
              return NotFound();
          }
            return await _context.peliculas.ToListAsync();
        }

        // GET: api/Peliculas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pelicula>> GetPelicula(int id)
        {
          if (_context.peliculas == null)
          {
              return NotFound();
          }
            var pelicula = await _context.peliculas.FindAsync(id);

            if (pelicula == null)
            {
                return NotFound();
            }

            return pelicula;
        }

        // PUT: api/Peliculas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPelicula(int id, Pelicula pelicula)
        {
            if (id != pelicula.codigo)
            {
                return BadRequest();
            }

            _context.Entry(pelicula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeliculaExists(id))
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

        // POST: api/Peliculas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pelicula>> PostPelicula(Pelicula pelicula)
        {
          if (_context.peliculas == null)
          {
              return Problem("Entity set 'MyDbContext.peliculas'  is null.");
          }
            _context.peliculas.Add(pelicula);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPelicula", new { id = pelicula.codigo }, pelicula);
        }

        // DELETE: api/Peliculas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePelicula(int id)
        {
            if (_context.peliculas == null)
            {
                return NotFound();
            }
            var pelicula = await _context.peliculas.FindAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            _context.peliculas.Remove(pelicula);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PeliculaExists(int id)
        {
            return (_context.peliculas?.Any(e => e.codigo == id)).GetValueOrDefault();
        }
    }
}
