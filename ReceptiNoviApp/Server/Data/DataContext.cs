using Microsoft.EntityFrameworkCore;
using ReceptiNoviApp.Shared;

namespace ReceptiNoviApp.Server.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		public DbSet<Recept> Recepti { get; set; }
		public DbSet<Kategorija> Kategorije { get; set; }
		public DbSet<Korisnik> Korisnici { get; set; }
		public DbSet<Recenzija> Recenzije { get; set; }

	}
}
