using ReceptiNoviApp.Shared;

namespace ReceptiNoviApp.Client.Services.RecenzijaService
{
    public interface IRecenzijaService
    {
        Task<double> Izracunaj(string id);

        Task<Recenzija> PostRecenzija(Recenzija recenzija);
    }
}
