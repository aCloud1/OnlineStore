using OnlineStore.Database;
using OnlineStore.Domain;

namespace OnlineStore.Services
{
	public class ItemService
	{

		public ItemService() { }

		public Item? createItem(Item item)
		{
			if (item.id == null)
				item.id = Id.generate();

			using (var db = new DatabaseContext())
			{
				db.items.Add(item);
				db.SaveChanges();
			};

			return item;
		}

		public void deleteItem(Item item)
		{
			using (var db = new DatabaseContext())
			{
				var temp = db.items.Where(x => x.id == item.id).First();
				db.items.Remove(temp);
				db.SaveChanges();
			};
		}

		public List<Item> listItems()
		{
			using (var db = new DatabaseContext())
			{
				var query = from i in db.items
							orderby i.name
							select i;
				return query.ToList();
			};
		}

		public List<Item> getItemsByShopId(string id)
		{
			List<Item> result;
			using (var db = new DatabaseContext())
			{
				result = db.items.Where(item => item.ShopId == id).ToList();
			}
			return result;
		}

		public Item? getItemById(string id)
		{
			using (var db = new DatabaseContext())
			{
				Item result = db.items.SingleOrDefault(i => i.id == id);
				return result;
			};
		}

		public Item? getItemByIdInShop(string item_id, string shop_id)
		{
			using (var db = new DatabaseContext())
			{
				return db.items.SingleOrDefault(item => (item.id == item_id) && (item.ShopId == shop_id));
			};
		}

		public void updateItem(Item updated_item)
		{
			using (var db = new DatabaseContext())
			{
				var item = db.items.FirstOrDefault(item => item.id == updated_item.id);
				if (item is not null) {
					item.name = updated_item.name;
					item.price = updated_item.price;
					item.category = updated_item.category;
					item.description = updated_item.description;
					db.SaveChanges();
				}
			}
		}
	}
}
