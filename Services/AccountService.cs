using Microsoft.AspNetCore.Mvc;

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
                new Employee(Id.generate(), "admin", "admin", new Person("ad", "min", "home", "+12345678901")),
                new Customer(Id.generate(), "user", "user", new Person("u", "ser", "home2", "+98765432109"))
            };
        }


        public Account? getAccountByEmail(string email_address)
		{
            Account? account = accounts.Find(acc => acc.email_address == email_address);
            if (account is null)
                throw new ArgumentException($"Account with email ${email_address} does not exist.");
            return account;
		}

		public Account? getAccountById(string id)
        {
            Account? account = accounts.Find(acc => acc.id == id);
            if (account is null)
                throw new ArgumentException($"Account with id {id} does not exist.");
            return account;
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

			string id = Id.generate();
            Account account = new Customer(id, email_address, password, personal_data);
            accounts.Add(account);
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
                throw new ArgumentException($"User entered a wrong password when logging into account {account.id}.");
        }
    }

    public static class ROLES
    {
        public const string Admin = "admin";

        public const string User = "user";
    }
}
