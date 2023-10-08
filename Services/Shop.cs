namespace OnlineStore.Services
{
    public class Shop
    {
        public string name;
        public StockManager stock_manager;

        public Shop()
        {
            name = "Shop1";
            stock_manager = new StockManager();
        }

        public Item getItemById(string itemId)
        {
            return stock_manager.getItemById(itemId);
        }
    }
}
