namespace OnlineStore.Services
{
    public class UserSession
    {
        public string email_address { get; set; }
        public string role { get; set; }

        public UserSession() { }

        public UserSession(string email_address, string role)
        {
            this.email_address = email_address;
            this.role = role;
        }
    }
}
