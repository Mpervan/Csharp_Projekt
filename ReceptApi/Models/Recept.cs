using System;
using System.Collections.Generic;

namespace Recepti.Models
{
    public partial class Recept
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Priprema { get; set; }
        public string? KratkiOpis { get; set; }
        public string? Sastojci { get; set; }
        public string? Img { get; set; }
        public string? Vege { get; set; }
        public long Idkorisnik { get; set; }
        public long Idkategorije { get; set; }
    }
}
