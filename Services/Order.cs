namespace OnlineStore.Services
{
    public class Order  // todo: not yet used
    {
        public string id { get; set; }
		public OrderStatus status { get; set; }
		public ShoppingCart shopping_cart { get; set; }

		public Order(ShoppingCart shopping_cart, OrderStatus status = OrderStatus.NOT_STARTED)
        {
            this.id = Id.generate();
            this.shopping_cart = shopping_cart;
			this.status = status;
        }
    }

    public enum OrderStatus
    {
		NOT_STARTED,    // waiting for a review
		DELIVERING,
		DELIVERED,      // waiting to be retrieved by customer
		COMPLETED
	}
}
