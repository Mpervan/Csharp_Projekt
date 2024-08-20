using ReceptiBlazor.Shared;

namespace ReceptiBlazor.Client.Services.KorisnikService
{
    public interface IKorisnikService
    {
        List<Korisnik> korisnici { get; set; }
        Task LoadKorisnici();
        void NoviKorisnik(Korisnik korisnik);
        Korisnik GetKorisnik(int id);
    }
}
