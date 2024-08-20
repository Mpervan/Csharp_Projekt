using ReceptiNoviApp.Shared;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;

namespace ReceptiNoviApp.Client.Services.KorisnikServices
{
    public class KorisnikService : IKorisnikService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService LocalStorage;
        public KorisnikService(HttpClient http, ILocalStorageService localStorage)
        {
            _httpClient = http;
            LocalStorage = localStorage;
        }
        public async Task<Korisnik> GetKorisnikByName(string name)
        {
            var result = await _httpClient.GetAsync($"api/Korisnik/{name}");
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new Korisnik { Username = message };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<Korisnik>();
            }
        }

        public async Task<List<Korisnik>> LoadKorisnici()
        {
            return await _httpClient.GetFromJsonAsync<List<Korisnik>>("api/Korisnik");
        }
        public async Task<string> Register(KorisnikDTO korisnik)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Auth/register", korisnik);
            var NoviKorisnik = await result.Content.ReadFromJsonAsync<Korisnik>();
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine(result.ToString());
                return "Neuspješan unos korisnika! \n Poteškoće na serveru...";
            }
            else
            {
                await _httpClient.PostAsJsonAsync("api/Korisnik", NoviKorisnik);
                return "Unos korisnika uspješan!";
            }
        }
        public async Task<string> Login(KorisnikDTO korisnik)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/login", korisnik);
            var token = await result.Content.ReadAsStringAsync();
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return "Neuspješan login!";
            }
            else
            {
                await LocalStorage.SetItemAsync("token", token);
                return "Uspješno ste logirani";
            }
        }
        //public async Task<string> EditLink(Recept recept, string name)
        //{
        //    Korisnik korisnik = new Korisnik();
        //    var korisnici = await _httpClient.GetFromJsonAsync<List<Korisnik>>("api/Korisnik");
        //    foreach (Korisnik k in korisnici)
        //    {
        //        if (k.Username == name)
        //        {
        //            korisnik = k;
        //        }
        //    }
        //    if (korisnik.Id == recept.Idkorisnik)
        //    {
        //        return "uredirecept/" + 
        //    }
        //}
    }
}
