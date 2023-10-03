namespace OnlineStore
{
	public class AccountService
	{
		private List<Account> accounts;

		public AccountService()
		{
			accounts = new List<Account>
			{
				new Employee(generateId(), "admin", "admin"),
				new Customer(generateId(), "user", "user")
			};
		}

		public Account? getAccountByEmail(string email)
		{
			return accounts.FirstOrDefault(x => x.email_address == email);
		}

		public Account createAccount(
			string first_name,
			string second_name,
			string phone_number,
			string email_address,
			string password
		)
		{
			string id = generateId();
			Account account = new Customer(id, email_address, password);
			accounts.Add(account);
			return account;
		}

		private string generateId()
		{
			return Guid.NewGuid().ToString();
		}
	}

	public static class ROLES
	{
		public const string Admin = "admin";

		public const string User = "user";
	}
}
