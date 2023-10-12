namespace OnlineStore.Services
{
    public class Item
    {
        public string id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public ItemCategory category { get; set; }

        public Item(string id, int price, string name = "", ItemCategory category = ItemCategory.UNCATEGORIZED)
        {
            this.id = id;
            this.price = price;
            this.name = name;
            this.category = category;
        }
    }

    public enum ItemFieldNames
    {
        ID = 0,
        NAME = 1,
        PRICE = 2,
        CATEGORY = 3
    }

    public enum ItemCategory
    {
        UNCATEGORIZED = 0,
        NO_CATEGORY = 1,
        CLOTHING = 2,
        FOOD = 3,
        TOOLS = 4
    }
}
