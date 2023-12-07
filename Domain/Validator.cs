using System.Text.RegularExpressions;

namespace OnlineStore.Domain
{
    public abstract class Validator
    {
    }

    public class AccountValidator : Validator
    {
        public Regex regex_name = new Regex(@"^[a-zA-z]+$");
        public Regex regex_password = new Regex(@"^[a-zA-Z0-9]{4,}$");
        public Regex regex_phone_number = new Regex(@"^[+]{1}[0-9]{11}$");
        public Regex regex_email_address = new Regex(@"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$");

        public void validateName(string name)
        {
            if (!regex_name.IsMatch(name))
                throw new ArgumentException("name can only contain characters");
        }

        public void validateEmailAddress(string email_address)
        {
            if (!regex_email_address.IsMatch(email_address))
                throw new ArgumentException("email address");
        }

        public void validatePassword(string password)
        {
            if (!regex_password.IsMatch(password))
                throw new ArgumentException("password must be at least 4 characters long");
        }

        public void validatePhoneNumber(string phone_number)
        {
            if (!regex_phone_number.IsMatch(phone_number))
                throw new ArgumentException("phone number must contain 11 digits that start with a plus symbol");
        }
    }
}
