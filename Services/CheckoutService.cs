namespace OnlineStore.Services
{
	public static class CheckoutService
	{
		public static double tax_rate;

		static CheckoutService()
		{
			tax_rate = 1.1;
		}

		public static double calculateTotal(List<Item> items)
		{
			return items.Sum(x => x.price);
		}

		public static double calculateTotal(params double[] prices)
		{
			return prices.Sum();
		}

		public static double applyTax(double total, double tax_rate)
		{
			return total * tax_rate;
		}

		public static Transaction createTransaction(Account account, double total)
		{
			return new Transaction(account, total);
		}

		public static Transaction createTransaction(Account account, params double[] prices)
		{
			return new Transaction(
				account,
				prices.Sum()
			);
		}
	}
}
