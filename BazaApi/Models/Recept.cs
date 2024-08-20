using System;
using System.Collections.Generic;

namespace Recepti.Models
{
    public partial class Recept
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
        public virtual Kategorija IdkategorijeNavigation { get; set; } = null!;
        public virtual Korisnik IdkorisnikNavigation { get; set; } = null!;
        public virtual ICollection<Recenzije> Recenzijes { get; set; }
    }
}
