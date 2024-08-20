using ReceptiNoviApp.Shared;
using System.Net.Http.Json;

namespace ReceptiNoviApp.Client.Services.ReceptServices
{
    public class ReceptService : IReceptService
    {
        private readonly HttpClient _httpClient;
        public ReceptService(HttpClient http)
        {
            _httpClient = http;
        }

		public async Task<Recept> GetReceptById(string id)
        {
            var result = await _httpClient.GetAsync($"api/Recept/{id}");
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new Recept { Name = message };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<Recept>();
            }
        }
        public async Task<List<Recept>> LoadRecepti()
        {
            return await _httpClient.GetFromJsonAsync<List<Recept>>("api/Recept");
        }

		public async Task<Recept> PostRecept(Recept recept)
		{
            var result = await _httpClient.PostAsJsonAsync("api/Recept", recept);
            return await result.Content.ReadFromJsonAsync<Recept>();

        }
        public async Task<Recept> UpdateRecept(Recept recept)
        {
            Recept OldRecept = await GetReceptById(recept.Id.ToString());
            OldRecept.Name = recept.Name;
            OldRecept.Priprema = recept.Priprema;
            OldRecept.KratkiOpis = recept.KratkiOpis;
            OldRecept.Sastojci = recept.Sastojci;
            OldRecept.Img = recept.Img;
            OldRecept.Vege = recept.Vege;
            OldRecept.Idkategorije = recept.Idkategorije;

            var result = await _httpClient.PutAsJsonAsync("api/Recept/" + recept.Id, OldRecept);
            return await result.Content.ReadFromJsonAsync<Recept>();

        }

        public async Task DeleteRecept(string id)
        {
            await _httpClient.DeleteAsync("api/Recept/delete/" + id);

        }
    }
}
