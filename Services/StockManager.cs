namespace OnlineStore.Services
{
	public class StockManager
	{
		public List<Item> items { get; set; }
		public Dictionary<string, int> stock { get; set; }
		public StockManager()
		{
			items = new List<Item>
			{
				new Item("01", 20),
				new Item("02", 10),
				new Item("03", 45),
				new Item("04", 80)
			};

			stock = new Dictionary<string, int>();

			foreach(var item in items)
			{
				stock.Add(item.id, 5);
			}
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
