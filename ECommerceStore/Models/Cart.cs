using System.Collections.Generic;
using System.Linq;

namespace ECommerceStore.Models
{
    public class Cart
    {
        private List<CartItem> _items = new List<CartItem>();
        private int _index = 1;

        public IEnumerable<CartItem> Items => _items;

        public void Add(Product product, int quantity)
        {
            CartItem item = _items.FirstOrDefault(i => i.Id == product.Id);
            if (item == null)
            {
                _items.Add(new CartItem
                {
                    Id = _index,
                    Product = product,
                    Quantity = quantity
                });

                _index++;
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void Remove(Product product)
        {
            _items.RemoveAll(i => i.Product.Id == product.Id);
        }

        public void Clear()
        {
            _items.Clear();
        }
    }
}
