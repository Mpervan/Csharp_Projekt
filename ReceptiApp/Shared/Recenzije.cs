using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptiApp.Shared
{
    public class Recenzije
    {
        public long Id { get; set; }
        public long Idkorisnik { get; set; }
        public long Idrecept { get; set; }
        public long Ocjena { get; set; }
    }
}
