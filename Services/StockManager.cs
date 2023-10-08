﻿namespace OnlineStore.Services
{
	public class StockManager
	{
		public List<Item> items_in_stock { get; set; }
		public StockManager()
		{
			items_in_stock = new List<Item>();
			items_in_stock.Add(new Item("0001", 10));
			items_in_stock.Add(new Item("0002", 54));
			items_in_stock.Add(new Item("0003", 21));
			items_in_stock.Add(new Item("0004", 10));
			items_in_stock.Add(new Item("0005", 54));
			items_in_stock.Add(new Item("0006", 21));
			items_in_stock.Add(new Item("0007", 54));
			items_in_stock.Add(new Item("0008", 21));

		}

		public Item getItemById(string id)
		{
			// todo: add error checking
			return items_in_stock.Find(item => item.id == id);
		}
	}
}