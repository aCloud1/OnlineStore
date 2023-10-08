namespace OnlineStore.Services
{
	public static class CheckoutService
	{
		public static int calculateTotal(List<Item> items)
		{
			return items.Sum(x => x.price);
		}
	}
}
