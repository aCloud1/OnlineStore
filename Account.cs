namespace OnlineStore
{
	public class Account
	{
		public string id;
		public string role;
		public string email;
		public string password;

		public Account(string id, string role, string email, string password) 
		{
			this.id = id;
			this.role = role;
			this.email = email;
			this.password = password;
		}
	}



	// todo: differentiante between these based on the domain of the email.


	// 
	public class Customer : Account
	{
		public Customer(string id, string email, string password): base(id, "User", email, password) { }
	}


	public interface EmployeeActions
	{
		public void ajustAvailableItemCount(int count);
	}

	// If a user is logging in with company's email, he is 
	public class Employee : Account, EmployeeActions
	{
		public Employee(string id, string email, string password): base(id, "Admin", email, password) { }

		public void ajustAvailableItemCount(int count)
		{
			throw new NotImplementedException();
		}
	}
}
