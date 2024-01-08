using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kundvagn
{
    public class Cart
    {
        public List<CartItem> CartItems { get; }

        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public void AddToCart(Product product, int quantity)
        {
            CartItem existingItem = CartItems.Find(item => item.Product == product);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                CartItems.Add(new CartItem(product, quantity));
            }
        }

        public void RemoveFromCart(Product product, int quantity)
        {
            CartItem existingItem = CartItems.Find(item => item.Product == product);

            if (existingItem != null)
            {
                if (quantity >= existingItem.Quantity)
                {
                    CartItems.Remove(existingItem);
                }
                else if (quantity > 0)
                {
                    existingItem.Quantity -= quantity;
                }
                // If the quantity is less than or equal to 0, do nothing (invalid input).
            }
        }

        public double CalculateTotalPrice()
        {
            return CartItems.Sum(item => item.Quantity * item.Product.Price);
        }
    }
}
