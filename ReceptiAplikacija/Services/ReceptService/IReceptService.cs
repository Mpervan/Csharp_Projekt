using ReceptiAplikacija.Data;

namespace ReceptiAplikacija.Services.ReceptService
{
    public interface IReceptService
    {
        List<Recept> Recepti { get; set; }
        void LoadRecepti();
        void PostRecept(Recept recept);
    }
}
