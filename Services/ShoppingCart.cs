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

		public void addItem(Item item)
		{
			items.Add(item);
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
	}
}
