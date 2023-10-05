namespace OnlineStore.Services
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
                new Employee(generateId(), "admin", "admin", new Person("ad", "min", "home", "+12345678901")),
                new Customer(generateId(), "user", "user", new Person("u", "ser", "home2", "+98765432109"))
            };
        }


        public Account? getAccountByEmail(string email_address)
		{
			return accounts.FirstOrDefault(acc => acc.email_address == email_address);
		}

		public Account? getAccountById(string id)
        {
            return accounts.FirstOrDefault(acc => acc.id == id);
        }

        public Account? createCustomerAccount(
                                        string email_address,
                                        string password,
                                        Person personal_data)
        {
            account_validator.validateName(personal_data.first_name);
            account_validator.validateName(personal_data.second_name);
            account_validator.validatePhoneNumber(personal_data.phone_number);
            account_validator.validateEmailAddress(email_address);
            account_validator.validatePassword(password);

            string id = generateId();
            Account account = new Customer(id, email_address, password, personal_data);
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
