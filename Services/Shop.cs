using System.Security.Policy;

namespace OnlineStore.Services
{
	public class Shop
	{
		public string id { get; set; }
		public string name { get; set; }
		public List<Item> items { get; set; }

		public Shop()
		{
			name = "Shop1";
		}

		public Item getItemById(string id)
		{
			Item item = items.Find(i => i.id == id);
			if (item is null)
				throw new ArgumentException($"Item {id} does not exist");

			if (getItemCount(id) <= 0)
				throw new ApplicationException($"Item {id} is out of stock");

			return item;
		}

		public int getItemCount(string id)
		{
			return 10;
		}
	}


	public class ShopQuantity {
		public string id;
		public string shop_id;
		public string item_id;
		public int quantity;
	}
}
