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

        public Account(string id, string role, string email_address, string password, Person personal_data)
        {
            this.id = id;
            this.role = role;
            this.email_address = email_address;
            this.password = password;
            this.personal_data = personal_data;
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


    public class Person
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
    }
}
