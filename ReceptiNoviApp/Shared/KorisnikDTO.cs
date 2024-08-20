using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptiNoviApp.Shared
{
    public class KorisnikDTO
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
