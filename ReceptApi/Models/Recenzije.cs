using System;
using System.Collections.Generic;

namespace Recepti.Models
{
    public partial class Recenzije
    {
        public long Id { get; set; }
        public long Idkorisnik { get; set; }
        public long Idrecept { get; set; }
        public long Ocjena { get; set; }
    }
}
