using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReceptiNoviApp.Server.Data;
using ReceptiNoviApp.Shared;

namespace ReceptiNoviApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorijaController : ControllerBase
    {
		private readonly DataContext Kontekst;

		public KategorijaController(DataContext context)
		{
			Kontekst = context;
		}
		[HttpGet]
		public ActionResult<List<Kategorija>> GetKategorije()
		{
			return Ok(Kontekst.Kategorije);
		}
		[HttpGet("{id}")]

		public ActionResult<Kategorija> GetKategorija(string id)
		{
			var kategorija = Kontekst.Kategorije.FirstOrDefault(p => p.Id == Int32.Parse(id));
			if (kategorija == null)
			{
				return NotFound("Nema kategorije na ovoj adresi!");
			}
			return Ok(kategorija);
		}
		[HttpPost]
		public async Task<ActionResult<Kategorija>> PostKategorija(Kategorija request)
		{
			Kontekst.Add(request);
			await Kontekst.SaveChangesAsync();
			return request;
		}
	}
}
