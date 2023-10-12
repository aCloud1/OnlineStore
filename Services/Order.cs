namespace OnlineStore.Services
{
    public class Order
    {
        public string id;
        public OrderStatus status;
        public Transaction transaction;

        public Order(Transaction transaction, OrderStatus status = OrderStatus.NOT_STARTED)
        {
            this.id = Id.generate();
            this.status = status;
            this.transaction = transaction;
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
