using ReceptiBlazor.Shared;

namespace ReceptiBlazor.Client.Services.KategorijaService
{
    public interface IKategorijaService
    {
        List<Kategorija> kategorije { get; set; }
        Task LoadKategorije();
        Kategorija GetKategorija(int id);
    }
}
