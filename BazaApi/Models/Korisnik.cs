using System;
using System.Collections.Generic;

namespace Recepti.Models
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Recepts = new HashSet<Recept>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Admin { get; set; }

        public virtual ICollection<Recept> Recepts { get; set; }
    }
}
