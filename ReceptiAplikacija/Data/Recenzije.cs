namespace ReceptiAplikacija.Data
{
    public class Recenzije
    {
        public long Id { get; set; }
        public long Idkorisnik { get; set; }
        public long Idrecept { get; set; }
        public long Ocjena { get; set; }
    }
}
