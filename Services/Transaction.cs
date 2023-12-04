using Microsoft.AspNetCore.Components.Web;

namespace OnlineStore.Services
{
	public class Transaction : IComparable<Transaction>, IEquatable<Transaction>
	{
		public string id { get; set; }
		public Account account { get; set; }
		public Order order { get; set; }
		public double total { get; set; }
		public DateOnly date { get; set; }  // todo: move to DateTime

		public Transaction()
		{
			this.id = Id.generate();
		}

		public Transaction(Account account, double total)
		{
			this.id = Id.generate();
			this.account = account;
			this.total = total;
			this.date = DateOnly.FromDateTime(DateTime.UtcNow);
		}

		public int CompareTo(Transaction? other)
		{
			if(other == null)
				return 1;

			int result = date.CompareTo(other.date);
			if(result == 0)
				result = total.CompareTo(other.total);
			return result;
		}

		public bool Equals(Transaction? other)
		{
			return date.Equals(other) &&
					 id.Equals(other.id) &&
				  total.Equals(other.total);
		}
	}
}
