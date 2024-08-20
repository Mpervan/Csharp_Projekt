using ReceptiNoviApp.Shared;
namespace ReceptiNoviApp.Client.Services.ReceptServices
{
    public interface IReceptService
    {
        Task<Recept> GetReceptById(string id);
        Task<List<Recept>> LoadRecepti();
        Task<Recept> PostRecept(Recept recept);
        Task<Recept> UpdateRecept(Recept recept);
        Task DeleteRecept(string id);
    }
}
