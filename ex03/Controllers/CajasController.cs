using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ex03.Data;
using ex03.Models;

namespace ex03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CajasController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CajasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Cajas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caja>>> Getcajas()
        {
          if (_context.cajas == null)
          {
              return NotFound();
          }
            return await _context.cajas.ToListAsync();
        }

        // GET: api/Cajas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Caja>> GetCaja(string id)
        {
          if (_context.cajas == null)
          {
              return NotFound();
          }
            var caja = await _context.cajas.FindAsync(id);

            if (caja == null)
            {
                return NotFound();
            }

            return caja;
        }

        // PUT: api/Cajas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaja(string id, Caja caja)
        {
            if (id != caja.numReferencia)
            {
                return BadRequest();
            }

            _context.Entry(caja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CajaExists(id))
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

        // POST: api/Cajas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Caja>> PostCaja(Caja caja)
        {
          if (_context.cajas == null)
          {
              return Problem("Entity set 'MyDbContext.cajas'  is null.");
          }
            _context.cajas.Add(caja);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CajaExists(caja.numReferencia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCaja", new { id = caja.numReferencia }, caja);
        }

        // DELETE: api/Cajas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaja(string id)
        {
            if (_context.cajas == null)
            {
                return NotFound();
            }
            var caja = await _context.cajas.FindAsync(id);
            if (caja == null)
            {
                return NotFound();
            }

            _context.cajas.Remove(caja);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CajaExists(string id)
        {
            return (_context.cajas?.Any(e => e.numReferencia == id)).GetValueOrDefault();
        }
    }
}
