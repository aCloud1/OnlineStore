namespace OnlineStore
{
	public class Shop
	{
		public StockManager stock_manager;
		public ShoppingCart shopping_cart;

		public Shop()
		{
			this.stock_manager = new StockManager();
			this.shopping_cart = new ShoppingCart(stock_manager);
		}

		public ShoppingCart getShoppingCart() { return this.shopping_cart; }
	}
}
