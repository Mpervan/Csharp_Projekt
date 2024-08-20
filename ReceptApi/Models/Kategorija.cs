using System;
using System.Collections.Generic;

namespace Recepti.Models
{
    public partial class Kategorija
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string? Icon { get; set; }
    }
}
