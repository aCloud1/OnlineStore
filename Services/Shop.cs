namespace OnlineStore.Services
{
    public class Shop
    {
        public StockManager stock_manager;
        public ShoppingCart shopping_cart;

        public Shop()
        {
            stock_manager = new StockManager();
            shopping_cart = new ShoppingCart(stock_manager);
        }

        public ShoppingCart getShoppingCart() { return shopping_cart; }
    }
}
