using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Services
{
    public abstract class Account
    {
        public string id { get; set; }
        public string role { get; set; }
		public string email_address { get; set; }
		public string password { get; set; }

		public Person personal_data { get; set; }
		public ShoppingCart temporary_cart { get; set; }
        public List<Transaction> transactions { get; set; }

        public Account(string id, string role, string email_address, string password, Person personal_data)
        {
            this.id = id;
            this.role = role;
            this.email_address = email_address;
            this.password = password;
            this.personal_data = personal_data;
            this.temporary_cart = new ShoppingCart();
            this.transactions = new List<Transaction>();
        }
    }


    public sealed class Customer : Account
    {
        public Customer(string id, string email_address, string password, Person personal_data)
            : base(id, ROLES.User, email_address, password, personal_data) { }
    }


    public sealed class Employee : Account, EmployeeActions
    {
        public Employee(string id, string email_address, string password, Person personal_data)
            : base(id, ROLES.Admin, email_address, password, personal_data) { }

        public void clearTransactions()
        {
            this.transactions.Clear();
        }

        public void changeOrderStatus(Order order, OrderStatus status)
        {
            order.status = status;
        }
    }


	public interface EmployeeActions
	{
		public void clearTransactions();
        public void changeOrderStatus(Order order, OrderStatus status);
	}

}
