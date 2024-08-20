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
    public class RecenzijesController : ControllerBase
    {
        private readonly ReceptiContext _context;

        public RecenzijesController(ReceptiContext context)
        {
            _context = context;
        }

        // GET: api/Recenzijes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recenzije>>> GetRecenzijes()
        {
          if (_context.Recenzijes == null)
          {
              return NotFound();
          }
            return await _context.Recenzijes.ToListAsync();
        }

        // GET: api/Recenzijes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recenzije>> GetRecenzije(long id)
        {
          if (_context.Recenzijes == null)
          {
              return NotFound();
          }
            var recenzije = await _context.Recenzijes.FindAsync(id);

            if (recenzije == null)
            {
                return NotFound();
            }

            return recenzije;
        }

        // PUT: api/Recenzijes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecenzije(long id, Recenzije recenzije)
        {
            if (id != recenzije.Id)
            {
                return BadRequest();
            }

            _context.Entry(recenzije).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecenzijeExists(id))
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

        // POST: api/Recenzijes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recenzije>> PostRecenzije(Recenzije recenzije)
        {
          if (_context.Recenzijes == null)
          {
              return Problem("Entity set 'ReceptiContext.Recenzijes'  is null.");
          }
            _context.Recenzijes.Add(recenzije);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecenzije", new { id = recenzije.Id }, recenzije);
        }

        // DELETE: api/Recenzijes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecenzije(long id)
        {
            if (_context.Recenzijes == null)
            {
                return NotFound();
            }
            var recenzije = await _context.Recenzijes.FindAsync(id);
            if (recenzije == null)
            {
                return NotFound();
            }

            _context.Recenzijes.Remove(recenzije);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecenzijeExists(long id)
        {
            return (_context.Recenzijes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
