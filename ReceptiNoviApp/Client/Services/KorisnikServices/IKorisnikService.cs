
using ReceptiNoviApp.Shared;

namespace ReceptiNoviApp.Client.Services.KorisnikServices
{
    public interface IKorisnikService
    {
        Task<Korisnik> GetKorisnikByName(string name);
        Task<List<Korisnik>> LoadKorisnici();
        Task<string> Register(KorisnikDTO korisnik);
        Task<string> Login(KorisnikDTO korisnik);
        //Task<string> EditLink(string id, string name);
    }
}
