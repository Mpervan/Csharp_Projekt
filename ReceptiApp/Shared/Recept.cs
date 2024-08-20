using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptiApp.Shared
{
    public class Recept
    {
        public Recept()
        {
            Recenzijes = new HashSet<Recenzije>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Priprema { get; set; }
        public string? KratkiOpis { get; set; }
        public string? Sastojci { get; set; }
        public string? Img { get; set; }
        public string? Vege { get; set; }
        public int Idkorisnik { get; set; }
        public int Idkategorije { get; set; }
        public virtual ICollection<Recenzije> Recenzijes { get; set; }
    }
}
