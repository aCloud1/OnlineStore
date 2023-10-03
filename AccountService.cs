namespace OnlineStore
{
	public class AccountService
	{
		private AccountValidator account_validator;
		private List<Account> accounts;

		public AccountService()
		{
			account_validator = new AccountValidator();

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

		public Account? createAccount(string first_name,
										string second_name,
										string phone_number,
										string email_address,
										string password)
		{
			account_validator.validateName(first_name);
			account_validator.validateName(second_name);
			account_validator.validatePhoneNumber(phone_number);
			account_validator.validateEmailAddress(email_address);
			account_validator.validatePassword(password);

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
