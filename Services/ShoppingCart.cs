namespace OnlineStore.Services
{
    public class ShoppingCart
    {
        private List<Item> items;
        private StockManager stock_manager;

        public ShoppingCart(StockManager stock_manager)
        {
            this.stock_manager = stock_manager;

            items = new List<Item>();
        }

        public void getItems() { }

        public void addItem(string id)
        {
            Item? item = stock_manager.getItemById(id);
            if (item != null)
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


        // todo: move to appropriate class
        public int calculateTotal()
        {
            int total = 0;
            foreach (var item in items)
                total += item.price;

            return total;
        }
    }
}
