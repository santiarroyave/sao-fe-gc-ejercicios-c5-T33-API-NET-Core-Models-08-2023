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
    public class SalasController : ControllerBase
    {
        private readonly MyDbContext _context;

        public SalasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Salas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sala>>> Getsalas()
        {
          if (_context.salas == null)
          {
              return NotFound();
          }
            return await _context.salas.ToListAsync();
        }

        // GET: api/Salas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sala>> GetSala(int id)
        {
          if (_context.salas == null)
          {
              return NotFound();
          }
            var sala = await _context.salas.FindAsync(id);

            if (sala == null)
            {
                return NotFound();
            }

            return sala;
        }

        // PUT: api/Salas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSala(int id, Sala sala)
        {
            if (id != sala.codigo)
            {
                return BadRequest();
            }

            _context.Entry(sala).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaExists(id))
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

        // POST: api/Salas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sala>> PostSala(Sala sala)
        {
          if (_context.salas == null)
          {
              return Problem("Entity set 'MyDbContext.salas'  is null.");
          }
            _context.salas.Add(sala);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSala", new { id = sala.codigo }, sala);
        }

        // DELETE: api/Salas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSala(int id)
        {
            if (_context.salas == null)
            {
                return NotFound();
            }
            var sala = await _context.salas.FindAsync(id);
            if (sala == null)
            {
                return NotFound();
            }

            _context.salas.Remove(sala);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaExists(int id)
        {
            return (_context.salas?.Any(e => e.codigo == id)).GetValueOrDefault();
        }
    }
}
