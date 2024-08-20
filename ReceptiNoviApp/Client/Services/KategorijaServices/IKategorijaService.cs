using ReceptiNoviApp.Shared;
namespace ReceptiNoviApp.Client.Services.KategorijaServices
{
    public interface IKategorijaService
    {
        Task<Kategorija> GetKategorijaById(string id);
        Task<List<Kategorija>> LoadKategorije();
        Task<Kategorija> PostKategorije(Kategorija ctg);
    }
}
