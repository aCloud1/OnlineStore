using OnlineStore.Database;
using System.Security.Policy;

namespace OnlineStore.Domain
{
    public class Shop
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Item> Items { get; set; }

        public Shop()
        {
            name = "Shop1";
        }
        public Shop(string name, List<Item> items)
        {
            this.name = name;
            Items = items;
        }

        public Item? getItemBy(string id)
        {
            return Items.Find(item => item.id == id);
        }
    }


    public class ShopQuantity
    {
        public string id;
        public string shop_id;
        public string item_id;
        public int quantity;
    }
}
