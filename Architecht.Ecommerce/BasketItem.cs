using System;

namespace Architecht.Ecommerce
{
    public class BasketItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }


        public int CalculatePrice()
        {
            if (Quantity>0)
            {
                return Quantity * 100;
            }
            throw new Exception("Test için method exception döndü");
        }
    }
}
