using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReceptiNoviApp.Server.Data;
using ReceptiNoviApp.Shared;

namespace ReceptiNoviApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
		private readonly DataContext Kontekst;

		public KorisnikController(DataContext context)
		{
			Kontekst = context;
		}
		[HttpGet]
		public ActionResult<List<Korisnik>> GetKorisnici()
		{
			return Ok(Kontekst.Korisnici);
		}
		[HttpGet("{name}")]

		public ActionResult<Korisnik> GetKorisnik(string name)
		{
			var korisnik = Kontekst.Korisnici.FirstOrDefault(p => p.Username == name);
			if (korisnik == null)
			{
				return NotFound("Nema korisnika na ovoj adresi!");
			}
			return Ok(korisnik);
		}
		[HttpPost]
		public async Task<ActionResult<Korisnik>> PostKorisnik(Korisnik request)
		{
			Kontekst.Add(request);
			await Kontekst.SaveChangesAsync();
            return request;
		}
	}
}
