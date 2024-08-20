using Newtonsoft.Json;
using ReceptiApp.Shared;
using System.Net.Http.Json;

namespace ReceptiApp.Client.Services.KorisnikService
{
    public class KorisnikService : IKorisnikService
    {
        public List<Korisnik> korisnici { get; set; } = new List<Korisnik>();

        public void LoadKorisnici()
        {
            korisnici = new List<Korisnik>();
            var client = new System.Net.WebClient().DownloadString("https://localhost:7146/api/korisniks");
            korisnici = JsonConvert.DeserializeObject<List<Korisnik>>(client);
        }

        public async void NoviKorisnik(Korisnik korisnik)
        {
            korisnik.Admin = 0;
            HttpClient klient = new HttpClient();
            klient.BaseAddress = new Uri("https://localhost:7146/api/");
            klient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            await klient.PostAsJsonAsync("korisniks", korisnik);
            korisnici.Add(korisnik);
        }
        public Korisnik GetKorisnik(int id)
        {
            return korisnici.SingleOrDefault(x => x.Id == id);
        }
    }
}
