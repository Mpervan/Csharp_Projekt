using ReceptiAplikacija.Data;

namespace ReceptiAplikacija.Services.KorisnikService
{
    public interface IKorisnikService
    {
        List<Korisnik> korisnici { get; set; }
        void LoadKorisnici();
        void NoviKorisnik(Korisnik korisnik);
        Korisnik GetKorisnik(int id);
    }
}
