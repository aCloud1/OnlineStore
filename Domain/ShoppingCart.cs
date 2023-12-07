using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain
{
    public class ShoppingCart
    {
        public string id { get; set; }
        public string account_id { get; set; }
        public List<Item> items { get; set; }

        public ShoppingCart()
        {
            id = Id.generate();
            items = new List<Item>();
        }

        public List<Item> getItems()
        {
            return items;
        }

        public Item getItemByIndex(int index)
        {
            return items[index];
        }

        public void addItem(Item item)
        {
            items.Add(item);
        }

        public void removeItemById(string id)
        {
            Item? i = items.Find(item => item.id == id);
            if (i != null)
                items.Remove(i);
        }

        public void clear()
        {
            items.Clear();
        }
    }
}
