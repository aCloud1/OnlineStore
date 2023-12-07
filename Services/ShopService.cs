using OnlineStore.Database;
using OnlineStore.Domain;

namespace OnlineStore.Services
{
	public class ShopService
	{

		public ShopService() { }

		public Shop? createShop(Shop shop)
		{
			if (shop.id == null)
				shop.id = Id.generate();

			foreach (var item in shop.Items)
				if (item.id == null)
					item.id = Id.generate();

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

		public Shop getShopById(string id)
		{
			using (var db = new DatabaseContext())
			{
				Shop result = db.shops.SingleOrDefault(s => s.id == id);
				return result;
			};
		}
	}
}
