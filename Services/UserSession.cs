namespace OnlineStore.Services
{
    public class UserSession
    {
        public string id { get; set; }
        public string role { get; set; }

        public UserSession() { }

        public UserSession(string id, string role)
        {
            this.id = id;
            this.role = role;
        }
    }
}
