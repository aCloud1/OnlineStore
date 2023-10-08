using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Services
{
    public abstract class Account
    {
        public string id;
        public string role;
        public string email_address;
        public string password;

        public Person personal_data;
        public ShoppingCart shopping_cart;
        public List<Transaction> transactions;

        public Account(string id, string role, string email_address, string password, Person personal_data)
        {
            this.id = id;
            this.role = role;
            this.email_address = email_address;
            this.password = password;
            this.personal_data = personal_data;
            this.shopping_cart = new ShoppingCart();
            this.transactions = new List<Transaction>();
        }
    }



    // todo: differentiante between these based on the domain of the email.


    // 
    public class Customer : Account
    {
        public Customer(string id, string email_address, string password, Person personal_data)
            : base(id, ROLES.User, email_address, password, personal_data) { }
    }


    public interface EmployeeActions
    {
        public void ajustAvailableItemCount(int count);
    }

    // If a user is logging in with company's email, he is
    public class Employee : Account, EmployeeActions
    {
        public Employee(string id, string email_address, string password, Person personal_data)
            : base(id, ROLES.Admin, email_address, password, personal_data) { }

        public void ajustAvailableItemCount(int count)
        {
            throw new NotImplementedException();
        }
    }


    public class Person : IFormattable
    {
        public string first_name;
        public string second_name;
        public string home_address;
        public string phone_number;

        public Person() {}

        public Person(string first_name, string second_name, string home_address, string phone_number)
        {
            this.first_name = first_name;
            this.second_name = second_name;
            this.home_address = home_address;
            this.phone_number = phone_number;
		}

		public string ToString(string? format, IFormatProvider? formatProvider)
		{
			string buffer = "";
            if (format != null)
            {
                switch (format.ToLower())
                {
                    case "text":
                        buffer = $"{first_name} {second_name} lives at {home_address} and is reachable by calling {phone_number}";
                        break;

                    case "json":
                        buffer += "{\n";
                        buffer += $"  \"first_name\": \"{first_name}\",\n";
                        buffer += $"  \"second_name\": \"{second_name}\",\n";
                        buffer += $"  \"home_address\": \"{home_address}\",\n";
                        buffer += $"  \"phone_number\": \"{phone_number}\"\n";
                        buffer += "}";
                        break;

                    default:
                        break;
                }
            }
            return buffer;
		}
	}
}
