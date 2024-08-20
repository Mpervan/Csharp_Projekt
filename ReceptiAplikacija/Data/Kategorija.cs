﻿namespace ReceptiAplikacija.Data
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
