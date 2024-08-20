namespace ReceptiAplikacija.Data
{
    public class Korisnik
    {
        public long Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public long Admin { get; set; }
    }
}
