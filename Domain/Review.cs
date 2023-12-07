namespace OnlineStore.Domain
{
    public class Review
    {
        public string id { get; set; }
        public Item item { get; set; }
        public Account account { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public int stars { get; set; }

        public Review(string id, Item item, Account account, string title, string body, int stars)
        {
            this.id = id;
            this.item = item;
            this.account = account;
            this.title = title;
            this.body = body;
            this.stars = stars;
        }
    }
}
