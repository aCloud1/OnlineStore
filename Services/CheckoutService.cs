namespace OnlineStore.Services
{
	public static class CheckoutService
	{
		public static int calculateTotal(List<Item> items)
		{
			return items.Sum(x => x.price);
		}

		public static Transaction createTransaction(string account_id, int total)
		{
			return new Transaction(account_id, total);
		}
	}
}
