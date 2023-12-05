using OnlineStore.Database;
using static System.Formats.Asn1.AsnWriter;

namespace OnlineStore.Services
{
	public class ShopService
	{

		public ShopService() { }

		public Shop? createShop(Shop shop)
		{
			if (shop.id == null)
				shop.id = Id.generate();

			using (var db = new DatabaseContext())
			{
				db.shops.Add(shop);
				db.SaveChanges();
			};

			return shop;
		}

		public List<Shop> listShops()
		{
			using (var db = new DatabaseContext())
			{
				var query = from s in db.shops
							orderby s.name
							select s;
				return query.ToList();
			};
		}
	}
}
