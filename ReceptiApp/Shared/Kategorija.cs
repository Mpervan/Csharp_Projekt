using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptiApp.Shared
{
    public class Kategorija
    {
        public Kategorija()
        {
            Recepts = new HashSet<Recept>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string? Icon { get; set; }

        public virtual ICollection<Recept> Recepts { get; set; }
    }
}
