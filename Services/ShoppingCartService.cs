using OnlineStore.Domain;
using System.Collections;

namespace OnlineStore.Services
{
	public class ShoppingCartService : IEnumerable<ShoppingCart>
	{
		// account id -> cart
		public Dictionary<string, ShoppingCart> carts;

		public ShoppingCartService()
		{
			carts = new Dictionary<string, ShoppingCart>();
		}

		public ShoppingCart this[string id]
		{
			get {
				ShoppingCart cart = null;
				if (carts.ContainsKey(id))
					cart = carts[id];
				return cart;
			}
			set
			{
				carts.Add(id, value);
			}
		}

		public void removeCartByAccountId(string id)
		{
			carts.Remove(id);
		}

		public IEnumerator<ShoppingCart> GetEnumerator()
		{
			return carts.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
