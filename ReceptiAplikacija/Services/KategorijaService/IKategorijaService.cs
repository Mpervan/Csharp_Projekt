using ReceptiAplikacija.Data;

namespace ReceptiAplikacija.Services.KategorijaService
{
	public interface IKategorijaService
	{
		List<Kategorija> kategorije { get; set; }
		void LoadKategorije();
		Kategorija GetKategorija(int id);
	}
}
