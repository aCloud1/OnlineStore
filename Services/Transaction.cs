namespace OnlineStore.Services
{
	public class Transaction
	{
		public string id;
		public string account_id;
		public int total;
		public DateOnly date;


		public Transaction()
		{
			this.id = Id.generate();
		}

		public Transaction(string account_id, int total)
		{
			this.id = Id.generate();
			this.account_id = account_id;
			this.total = total;
			this.date = DateOnly.FromDateTime(DateTime.UtcNow);
		}
	}
}
