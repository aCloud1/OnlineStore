using OnlineStore.Services;
using System.Data.Entity;

namespace OnlineStore.Database

{
	public class DatabaseContext : DbContext
	{
		public DbSet<Account> accounts { get; set; }
		public DbSet<Item> items { get; set; }
		public DbSet<Order> orders { get; set; }
		public DbSet<Shop> shops { get; set; }
		public DbSet<ShoppingCart> shopping_carts { get; set; }
		public DbSet<Transaction> transaction { get; set; }
		public DbSet<Review> reviews { get; set; }
	}
}
