using OnlineStore.Domain;
using System.Data.Entity;

namespace OnlineStore.Database

{
    public class DatabaseContext : DbContext
	{
		public DbSet<Account> accounts { get; set; }
		public DbSet<Item> items { get; set; }
		public DbSet<Shop> shops { get; set; }
		public DbSet<Transaction> transactions { get; set; }
		public DbSet<Review> reviews { get; set; }
		public DbSet<Person> people { get; set; }
	}
}
