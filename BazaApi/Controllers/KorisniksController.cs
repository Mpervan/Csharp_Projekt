using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recepti.Data;
using Recepti.Models;

namespace BazaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniksController : ControllerBase
    {
        private readonly ReceptiContext _context;

        public KorisniksController(ReceptiContext context)
        {
            _context = context;
        }

        // GET: api/Korisniks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Korisnik>>> GetKorisniks()
        {
          if (_context.Korisniks == null)
          {
              return NotFound();
          }
            return await _context.Korisniks.ToListAsync();
        }

        // GET: api/Korisniks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Korisnik>> GetKorisnik(long id)
        {
          if (_context.Korisniks == null)
          {
              return NotFound();
          }
            var korisnik = await _context.Korisniks.FindAsync(id);

            if (korisnik == null)
            {
                return NotFound();
            }

            return korisnik;
        }

        // PUT: api/Korisniks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKorisnik(long id, Korisnik korisnik)
        {
            if (id != korisnik.Id)
            {
                return BadRequest();
            }

            _context.Entry(korisnik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KorisnikExists(id))
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

        // POST: api/Korisniks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Korisnik>> PostKorisnik(Korisnik korisnik)
        {
          if (_context.Korisniks == null)
          {
              return Problem("Entity set 'ReceptiContext.Korisniks'  is null.");
          }
            _context.Korisniks.Add(korisnik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKorisnik", new { id = korisnik.Id }, korisnik);
        }

        // DELETE: api/Korisniks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKorisnik(long id)
        {
            if (_context.Korisniks == null)
            {
                return NotFound();
            }
            var korisnik = await _context.Korisniks.FindAsync(id);
            if (korisnik == null)
            {
                return NotFound();
            }

            _context.Korisniks.Remove(korisnik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KorisnikExists(long id)
        {
            return (_context.Korisniks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
