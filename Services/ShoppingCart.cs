using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Services
{
	public class ShoppingCart
	{
		[Key, ForeignKey("account")]
		public string id { get; set; }
		public Account account { get; set; }
		public List<Item> items { get; set; }

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
