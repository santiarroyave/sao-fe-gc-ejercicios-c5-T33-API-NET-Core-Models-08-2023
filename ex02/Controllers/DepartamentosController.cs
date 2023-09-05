using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ex02.Data;
using ex02.Models;

namespace ex02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly MyDbContext _context;

        public DepartamentosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Departamentoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentos()
        {
          if (_context.Departamentos == null)
          {
              return NotFound();
          }
            return await _context.Departamentos.ToListAsync();
        }

        // GET: api/Departamentoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
          if (_context.Departamentos == null)
          {
              return NotFound();
          }
            var departamento = await _context.Departamentos.FindAsync(id);

            if (departamento == null)
            {
                return NotFound();
            }

            return departamento;
        }

        // PUT: api/Departamentoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamento(int id, Departamento departamento)
        {
            if (id != departamento.codigo)
            {
                return BadRequest();
            }

            _context.Entry(departamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentoExists(id))
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

        // POST: api/Departamentoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Departamento>> PostDepartamento(Departamento departamento)
        {
          if (_context.Departamentos == null)
          {
              return Problem("Entity set 'MyDbContext.Departamentos'  is null.");
          }
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartamento", new { id = departamento.codigo }, departamento);
        }

        // DELETE: api/Departamentoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            if (_context.Departamentos == null)
            {
                return NotFound();
            }
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }

            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartamentoExists(int id)
        {
            return (_context.Departamentos?.Any(e => e.codigo == id)).GetValueOrDefault();
        }
    }
}
