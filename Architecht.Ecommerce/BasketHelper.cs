using System.Collections.Generic;
using System.Linq;
using System;

namespace Architecht.Ecommerce
{
    public class BasketHelper : IDisposable
    {
        private readonly List<BasketItem> basketItems;
        public BasketHelper()
        {
            basketItems = new List<BasketItem>();
        }
        public void Add(BasketItem cartItem)
        {
            basketItems.Add(cartItem);
        }
        public void Remove(int productId)
        {
            var product = basketItems.FirstOrDefault(t => t.Product.Id == productId);
            basketItems.Remove(product);
        }
        public List<BasketItem> BasketItems
        {
            get
            {
                return basketItems;
            }
        }
        public void Clear()
        {
            basketItems.Clear();
        }
        public decimal TotalPrice()
        {
            return basketItems.Sum(t => t.Quantity * t.Product.UnitPrice);
        }
        public int TotalItems()
        {
            return basketItems.Count;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
