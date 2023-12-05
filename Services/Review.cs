namespace OnlineStore.Services
{
    public class Review
    {
        public Item item { get; set; }
        public Account account { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public int stars { get; set; }

        public Review(Item item, Account account, string title, string body, int stars)
        {
            this.item = item;
            this.account = account;
            this.title = title;
            this.body = body;
            this.stars = stars;
        }
    }
}
