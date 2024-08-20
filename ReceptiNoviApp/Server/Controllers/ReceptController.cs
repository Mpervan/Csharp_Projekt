using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceptiNoviApp.Server.Data;
using ReceptiNoviApp.Shared;

namespace ReceptiNoviApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptController : ControllerBase
    {
		private readonly DataContext Kontekst;

		public ReceptController(DataContext context) 
		{
			Kontekst = context;
		}
        [HttpGet]
		public ActionResult<List<Recept>> GetRecepti() 
		{
			return Ok(Kontekst.Recepti);
		}
        [HttpGet("{id}")]

		public ActionResult<Recept> GetRecept(string id)
        {
			var recept = Kontekst.Recepti.FirstOrDefault(p => p.Id == Int32.Parse(id));
			if(recept == null)
            {
				return NotFound("Nema recepta na ovoj adresi!");
            }
			return Ok(recept);
        }
		[HttpPost]
		public async Task<ActionResult<Recept>> PostRecept(Recept request)
		{
			Kontekst.Add(request);
			await Kontekst.SaveChangesAsync();
			return request;
		}
        [HttpPut("{id}")]
        public async Task<ActionResult<Recept>> PutRecept(string id, Recept recept)
        {
            if (Int32.Parse(id) != recept.Id)
            {
                return BadRequest();
            }

            Kontekst.Entry(recept).State = EntityState.Modified;

            try
            {
                await Kontekst.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceptExists(Int32.Parse(id)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return recept;
        }

        [HttpDelete("delete/{id}")]
		public async Task<IActionResult> Delete(long id)
        {
            if (Kontekst.Recepti == null)
            {
                return NotFound();
            }

            var recept = Kontekst.Recepti.FirstOrDefault(r => r.Id == id);
            if (recept == null)
            {
                return NotFound();
            }

            Kontekst.Recepti.Remove(recept);
            await Kontekst.SaveChangesAsync();

            return NoContent();
        }
        private bool ReceptExists(long id)
        {
            return (Kontekst.Recepti?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
