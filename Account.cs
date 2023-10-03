namespace OnlineStore
{
    public abstract class Account
    {
        public string id;
        public string role;
        public string email_address;
        public string password;

        public Account(string id, string role, string email_address, string password)
        {
            this.id = id;
            this.role = role;
            this.email_address = email_address;
            this.password = password;
        }
    }



    // todo: differentiante between these based on the domain of the email.


    // 
    public class Customer : Account
    {
        public Customer(string id, string email_address, string password) : base(id, ROLES.User, email_address, password) { }
    }


    public interface EmployeeActions
    {
        public void ajustAvailableItemCount(int count);
    }

    // If a user is logging in with company's email, he is
    public class Employee : Account, EmployeeActions
    {
        public Employee(string id, string email_address, string password) : base(id, ROLES.Admin, email_address, password) { }

        public void ajustAvailableItemCount(int count)
        {
            throw new NotImplementedException();
        }
    }
}
