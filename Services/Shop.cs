namespace OnlineStore.Services
{
    public class Shop
    {
        public StockManager stock_manager;

        public Shop()
        {
            stock_manager = new StockManager();
        }
    }
}
