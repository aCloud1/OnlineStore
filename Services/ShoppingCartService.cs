using OnlineStore.Domain;

namespace OnlineStore.Services
{
	public class ShoppingCartService
	{
		public Dictionary<string, ShoppingCart> carts;

		public ShoppingCartService()
		{
			carts = new Dictionary<string, ShoppingCart>();
		}

		/*
		public void addItemToCart(string cart_id, Item item)
		{
			ShoppingCart cart = getCartBy(cart_id);
			if(cart is null)
			{
				cart = new ShoppingCart();
				carts.Add(cart);
			}
			cart.addItem(item);
		}
		*/

		public ShoppingCart? getCartByAccountId(string id)
		{
			ShoppingCart cart = null;
			if(carts.ContainsKey(id))
				cart = carts[id];
			return cart;
		}

		public void removeCartByAccountId(string id)
		{
			carts.Remove(id);
		}
	}
}
