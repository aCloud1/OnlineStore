using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using OnlineStore.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Domain
{
    public abstract class Account
    {
        public string id { get; set; }
        public string role { get; set; }
        public string email_address { get; set; }
        public string password { get; set; }

        public string PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person PersonalData { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public List<Transaction> transactions { get; set; }

        public Account() { }

        public Account(string id, string role, string email_address, string password, Person personal_data)
        {
            this.id = id;
            this.role = role;
            this.email_address = email_address;
            this.password = password;
            PersonalData = personal_data;
            ShoppingCart = new ShoppingCart();
            transactions = new List<Transaction>();
        }
    }


    public sealed class Customer : Account
    {
        public Customer() : base() { }

        public Customer(string id, string email_address, string password, Person personal_data)
            : base(id, ROLES.User, email_address, password, personal_data) { }
    }


    public sealed class Employee : Account, EmployeeActions
    {
        public Employee() : base() { }

        public Employee(string id, string email_address, string password, Person personal_data)
            : base(id, ROLES.Admin, email_address, password, personal_data) { }

        public void clearTransactions()
        {
            transactions.Clear();
        }
    }


    public interface EmployeeActions
    {
        public void clearTransactions();
    }

}
