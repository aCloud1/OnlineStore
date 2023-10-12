namespace OnlineStore.Services
{
	public sealed class StockManager
	{
		private static StockManager instance = null;
		public List<Item> items { get; set; }
		public Dictionary<string, int> stock { get; set; }
		
		private StockManager()
		{
			items = new List<Item>
			{
				new Item("01", 20, "Hat1", ItemCategory.CLOTHING),
				new Item("02", 20, "Hat2", ItemCategory.CLOTHING),
				new Item("03", 60, "Jacket", ItemCategory.CLOTHING),
				new Item("04", 80, "Winter Coat", ItemCategory.CLOTHING),
				new Item("05", 20, "Hammer", ItemCategory.TOOLS),
				new Item("06", 25, "Drill", ItemCategory.TOOLS),
				new Item("07", 40, "Shovel", ItemCategory.TOOLS),
				new Item("08", 2, "Apple", ItemCategory.FOOD),
				new Item("09", 18, "Apple Pie", ItemCategory.FOOD),
				new Item("10", 20, "Pizza", ItemCategory.FOOD),
				new Item("11", 8, "Bread", ItemCategory.FOOD),
				new Item("12", 100, "Generic Item", ItemCategory.UNCATEGORIZED)
			};

			stock = new Dictionary<string, int>();

			foreach(var item in items)
			{
				stock.Add(item.id, 5);
			}
		}

		public static StockManager Instance()
		{
			if(instance == null)
				instance = new StockManager();
			return instance;
		}

		public Item getItemById(string id)
		{
			Item item = items.Find(i => i.id == id);
			if (item is null)
				throw new ArgumentException($"Item {id} does not exist");

			if (getItemCount(id) <= 0)
				throw new ApplicationException($"Item {id} is out of stock");

			stock[id]--;
			return item;
		}

		public int getItemCount(string id)
		{
			return stock[id];
		}
	}
}
