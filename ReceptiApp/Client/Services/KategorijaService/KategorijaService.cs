using Newtonsoft.Json;
using ReceptiApp.Shared;

namespace ReceptiApp.Client.Services.KategorijaService
{
    public class KategorijaService : IKategorijaService
    {
		public List<Kategorija> kategorije { get; set; } = new List<Kategorija>();
		public void LoadKategorije()
		{
			kategorije = new List<Kategorija>();
			var client = new System.Net.WebClient().DownloadString("https://localhost:7146/api/kategorijas");
			kategorije = JsonConvert.DeserializeObject<List<Kategorija>>(client);
		}
		public Kategorija GetKategorija(int id)
		{
			return kategorije.SingleOrDefault(x => x.Id == id);
		}
	}
}
