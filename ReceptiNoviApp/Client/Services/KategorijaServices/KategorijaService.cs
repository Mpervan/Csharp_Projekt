using ReceptiNoviApp.Shared;
using System.Net.Http.Json;

namespace ReceptiNoviApp.Client.Services.KategorijaServices
{
    public class KategorijaService : IKategorijaService
    {
        private readonly HttpClient _httpClient;
        public KategorijaService(HttpClient http)
        {
            _httpClient = http;
        }
        
        public async Task<Kategorija> GetKategorijaById(string id)
        {
            var result = await _httpClient.GetAsync($"api/Kategorija/{id}");
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new Kategorija { Name = message };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<Kategorija>();
            }
        }

        public async Task<List<Kategorija>> LoadKategorije()
        {
            return await _httpClient.GetFromJsonAsync<List<Kategorija>>("api/Kategorija");
        }

        public async Task<Kategorija> PostKategorije(Kategorija ctg)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Kategorija", ctg);
            return await result.Content.ReadFromJsonAsync<Kategorija>();
        }
    }
}
