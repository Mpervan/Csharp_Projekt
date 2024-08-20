using Newtonsoft.Json;
using ReceptiBlazor.Shared;

namespace ReceptiBlazor.Client.Services.KategorijaService
{
    public class KategorijaService : IKategorijaService
    {
		public List<Kategorija> kategorije { get; set; } = new List<Kategorija>();
		public async Task LoadKategorije()
		{
			kategorije = new List<Kategorija>();
			using var client = new HttpClient();

			var result = await client.GetAsync("https://localhost:7146/api/kategorijas");
			Console.WriteLine("msg: "+ result);
			//var client = new System.Net.Http.HttpClient.DownloadString("https://localhost:7146/api/kategorijas");
			//kategorije = JsonConvert.DeserializeObject<List<Kategorija>>(client);
		}
		public Kategorija GetKategorija(int id)
		{
			return kategorije.SingleOrDefault(x => x.Id == id);
		}
	}
}
