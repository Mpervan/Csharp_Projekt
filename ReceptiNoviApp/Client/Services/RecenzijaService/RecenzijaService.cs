using ReceptiNoviApp.Shared;
using System.Net.Http.Json;

namespace ReceptiNoviApp.Client.Services.RecenzijaService
{
    public class RecenzijaService : IRecenzijaService
    {
        private readonly HttpClient _httpClient;
        public RecenzijaService(HttpClient http)
        {
            _httpClient = http;
        }
        public async Task<double> Izracunaj(string id)
        {
            double result = 0;
            double brojac = 0;
            var recenzijas = await _httpClient.GetFromJsonAsync<List<Recenzija>>("api/Recenzije");
            foreach (Recenzija r in recenzijas) if (r.Idrecept == Int32.Parse(id)) 
            {
                    result += Convert.ToDouble(r.Ocjena);
                    brojac += 1;
            }
            return (result/brojac);
        }

        public async Task<Recenzija> PostRecenzija(Recenzija recenzija)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Recenzije", recenzija);
            return await result.Content.ReadFromJsonAsync<Recenzija>();

        }
    }
}
