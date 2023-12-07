using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Domain
{
    public class Item
    {
        public string id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public ItemCategory category { get; set; }

        public string ShopId { get; set; }
        [ForeignKey("ShopId")]
        public virtual Shop Shop { get; set; }
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
