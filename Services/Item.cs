namespace OnlineStore.Services
{
    public class Item
    {
        public string id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string category { get; set; }

        public Item(string id, int price)
        {
            this.id = id;
            this.price = price;
        }
    }
}
