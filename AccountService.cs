namespace OnlineStore
{
	public class AccountService
	{
		private List<Account> accounts;

		public AccountService()
		{
			accounts = new List<Account>
			{
				//new Account("00", "Admin", "admin", "admin"),
				new Employee("00", "admin", "admin"),
				new Customer("01", "user", "user")
			};
		}

		public Account? getAccountByEmail(string email)
		{
			return accounts.FirstOrDefault(x => x.email == email);
		}
	}
}
