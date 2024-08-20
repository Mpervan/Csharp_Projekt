using System;
using System.Collections.Generic;

namespace Recepti.Models
{
    public partial class Recenzije
    {
        public int Id { get; set; }
        public int Idkorisnik { get; set; }
        public int Idrecept { get; set; }
        public int Ocjena { get; set; }

        public virtual Recept IdreceptNavigation { get; set; } = null!;
    }
}
