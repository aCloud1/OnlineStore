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
    }
}
