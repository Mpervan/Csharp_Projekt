using Newtonsoft.Json;
using ReceptiApp.Shared;
using System.Net.Http.Json;

namespace ReceptiApp.Client.Services.ReceptService
{
    public class ReceptService : IReceptService
    {
		public List<Recept> Recepti { get; set; } = new List<Recept>();

		public void LoadRecepti()
		{
			Recepti = new List<Recept>();
			var client = new System.Net.WebClient().DownloadString("https://localhost:7146/api/recepts");
			Recepti = JsonConvert.DeserializeObject<List<Recept>>(client);
		}

		public async void PostRecept(Recept recept)
		{
			HttpClient klient = new HttpClient();
			klient.BaseAddress = new Uri("https://localhost:7146/api/");
			klient.DefaultRequestHeaders.Accept.Add(
			new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
			await klient.PostAsJsonAsync("recepts", recept);
			Recepti.Add(recept);
		}
	}
}
