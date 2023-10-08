namespace OnlineStore.Services
{
	public class ShoppingCart
	{
		public string id;
		public List<Item> items;

		public ShoppingCart()
		{
			this.id = Id.generate();
			items = new List<Item>();

					items.Add(new Item("01", 10));
					items.Add(new Item("02", 15));
					items.Add(new Item("03", 8));
		}

		public List<Item> getItems()
		{
			return items;
		}

		public Item getItemByIndex(int index)
		{
			// todo: add error checking
			return items[index];
		}

		public void addItem(string id)
		{
		}

		public void removeItemById(string id)
		{
			Item? i = items.Find(item => item.id == id);
			if (i != null)
				items.Remove(i);
		}

		public void clear()
		{
			items.Clear();
		}


		// todo: move to appropriate class
		public int calculateTotal()
		{
			int total = 0;
			foreach (var item in items)
				total += item.price;

			return total;
		}
	}
}
