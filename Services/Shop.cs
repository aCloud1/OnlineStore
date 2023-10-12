namespace OnlineStore.Services
{
    public class Shop
    {
        public string name;

        public List<Item> items_in_display;
        public StockManager stock_manager;

        public Shop()
        {
            name = "Shop1";
            stock_manager = StockManager.Instance();
            items_in_display = stock_manager.items;
        }

        public Item getItemById(string itemId)
        {
            return stock_manager.getItemById(itemId);
        }

        /*
        public List<Item> filter(Predicate<> pr, ItemFieldNames field)
        {
            List<Item> results = new List<Item>();
            switch(field)
            {
				case ItemFieldNames.Id:
					stock_manager.items.FindAll(item => pr(item.id));
					break;

				case ItemFieldNames.Name:
					stock_manager.items.FindAll(item => pr(item.name));
					break;

                case ItemFieldNames.Price:
					stock_manager.items.FindAll(item => pr(item.price));
                    break;

				case ItemFieldNames.Category:
					stock_manager.items.FindAll(item => pr(item.category));
                    break;

				default:
                    break;
            }
            return results;
        }
        */
    }
}
