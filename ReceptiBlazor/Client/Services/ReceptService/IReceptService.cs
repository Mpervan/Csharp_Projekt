using ReceptiBlazor.Shared;

namespace ReceptiBlazor.Client.Services.ReceptService
{
    public interface IReceptService
    {
        List<Recept> Recepti { get; set; }
        Task LoadRecepti();
        void PostRecept(Recept recept);
    }
}
