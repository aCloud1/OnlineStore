using OnlineStore.Database;
using OnlineStore.Domain;

namespace OnlineStore.Services
{
	public class TransactionService
	{
		public TransactionService()
		{
		}

		public Transaction? createTransaction(Transaction transaction)
		{
			if (transaction.id == null)
				transaction.id = Id.generate();

			using (var db = new DatabaseContext())
			{
				db.transactions.Add(transaction);
				db.SaveChanges();
			};

			return transaction;
		}

		public List<Transaction> listTransactions(string account_id)
		{
			using (var db = new DatabaseContext())
			{
				var query = from t in db.transactions
							select t;
				return query.ToList();
			};
		}
	}
}
