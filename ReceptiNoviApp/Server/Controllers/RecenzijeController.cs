using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReceptiNoviApp.Server.Data;
using ReceptiNoviApp.Shared;

namespace ReceptiNoviApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecenzijeController : ControllerBase
    {
		private readonly DataContext Kontekst;

		public RecenzijeController(DataContext context)
		{
			Kontekst = context;
		}
		[HttpGet]
		public ActionResult<List<Recenzija>> GetRecenzija()
		{
			return Ok(Kontekst.Recenzije);
		}
		[HttpGet("{id}")]

		public ActionResult<Recenzija> GetRecenzija(string id)
		{
			var recept = Kontekst.Recenzije.FirstOrDefault(p => p.Id == Int32.Parse(id));
			if (recept == null)
			{
				return NotFound("Nema recenzije na ovoj adresi!");
			}
			return Ok(recept);
		}
		[HttpPost]
		public async Task<ActionResult<Recenzija>> PostRecenzija(Recenzija request)
		{
			Kontekst.Add(request);
			await Kontekst.SaveChangesAsync();
			return request;
		}
	}
}
