using System;
using System.Collections.Generic;

namespace Recepti.Models
{
    public partial class Korisnik
    {
        public long Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public long Admin { get; set; }
    }
}
