using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recepti.Data;
using Recepti.Models;

namespace ReceptApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptsController : ControllerBase
    {
        private readonly ReceptiContext _context;

        public ReceptsController(ReceptiContext context)
        {
            _context = context;
        }

        // GET: api/Recepts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recept>>> GetRecepts()
        {
          if (_context.Recepts == null)
          {
              return NotFound();
          }
            return await _context.Recepts.ToListAsync();
        }

        // GET: api/Recepts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recept>> GetRecept(long id)
        {
          if (_context.Recepts == null)
          {
              return NotFound();
          }
            var recept = await _context.Recepts.FindAsync(id);

            if (recept == null)
            {
                return NotFound();
            }

            return recept;
        }

        // PUT: api/Recepts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecept(long id, Recept recept)
        {
            if (id != recept.Id)
            {
                return BadRequest();
            }

            _context.Entry(recept).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceptExists(id))
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

        // POST: api/Recepts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recept>> PostRecept(Recept recept)
        {
          if (_context.Recepts == null)
          {
              return Problem("Entity set 'ReceptiContext.Recepts'  is null.");
          }
            _context.Recepts.Add(recept);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecept", new { id = recept.Id }, recept);
        }

        // DELETE: api/Recepts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecept(long id)
        {
            if (_context.Recepts == null)
            {
                return NotFound();
            }
            var recept = await _context.Recepts.FindAsync(id);
            if (recept == null)
            {
                return NotFound();
            }

            _context.Recepts.Remove(recept);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReceptExists(long id)
        {
            return (_context.Recepts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
