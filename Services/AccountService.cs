using OnlineStore.Database;
using OnlineStore.Domain;
using OnlineStore.Errors;

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
                new Employee(Id.generate(), "admin", "admin", new Person("admin", "01", "home", "+12345678901")),
                new Customer(Id.generate(), "user", "user", new Person("user", "01", "home2", "+98765432109"))
            };
        }


        public Account? getAccountByEmail(string email_address)
		{
			using (var db = new DatabaseContext())
			{
                var result = db.accounts.FirstOrDefault(a => a.email_address == email_address);
				return result;
			};
		}

		public Account? getAccountById(string id)
        {
			using (var db = new DatabaseContext())
			{
				var account = db.accounts.FirstOrDefault(a => a.id == id);
                var personal_data = db.people.FirstOrDefault(p => p.id == account.PersonId);
                account.ShoppingCart = new ShoppingCart();
				return account;
			};
        }

        public Account? createCustomerAccount(Account account)
        {
			account_validator.validateName(account.PersonalData.first_name);
			account_validator.validateName(account.PersonalData.second_name);
			account_validator.validatePhoneNumber(account.PersonalData.phone_number);
			account_validator.validateEmailAddress(account.email_address);
			account_validator.validatePassword(account.password);

			if (account.PersonalData.id == null)
				account.PersonalData.id = Id.generate();           
			
            using (var db = new DatabaseContext())
			{
				db.accounts.Add(account);
				db.SaveChanges();
			};

			return account;
        }

        public void updateAccount(string account_id)
        {
            Account? account;
			try
			{
				account = getAccountById(account_id);
			}
            catch(ArgumentNullException e)
            {

            }
        }

        public void matchPasswords(Account account, string password)
        {
            if (account.password != password)
                throw new InvalidCredentials("wrong email or password");
        }
	}

    public static class ROLES
    {
        public const string Admin = "admin";

        public const string User = "user";
    }
}
