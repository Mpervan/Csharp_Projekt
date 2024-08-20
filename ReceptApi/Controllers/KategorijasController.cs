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
    public class KategorijasController : ControllerBase
    {
        private readonly ReceptiContext _context;

        public KategorijasController(ReceptiContext context)
        {
            _context = context;
        }

        // GET: api/Kategorijas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kategorija>>> GetKategorijas()
        {
          if (_context.Kategorijas == null)
          {
              return NotFound();
          }
            return await _context.Kategorijas.ToListAsync();
        }

        // GET: api/Kategorijas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kategorija>> GetKategorija(long id)
        {
          if (_context.Kategorijas == null)
          {
              return NotFound();
          }
            var kategorija = await _context.Kategorijas.FindAsync(id);

            if (kategorija == null)
            {
                return NotFound();
            }

            return kategorija;
        }

        // PUT: api/Kategorijas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKategorija(long id, Kategorija kategorija)
        {
            if (id != kategorija.Id)
            {
                return BadRequest();
            }

            _context.Entry(kategorija).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategorijaExists(id))
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

        // POST: api/Kategorijas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kategorija>> PostKategorija(Kategorija kategorija)
        {
          if (_context.Kategorijas == null)
          {
              return Problem("Entity set 'ReceptiContext.Kategorijas'  is null.");
          }
            _context.Kategorijas.Add(kategorija);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKategorija", new { id = kategorija.Id }, kategorija);
        }

        // DELETE: api/Kategorijas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKategorija(long id)
        {
            if (_context.Kategorijas == null)
            {
                return NotFound();
            }
            var kategorija = await _context.Kategorijas.FindAsync(id);
            if (kategorija == null)
            {
                return NotFound();
            }

            _context.Kategorijas.Remove(kategorija);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KategorijaExists(long id)
        {
            return (_context.Kategorijas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
