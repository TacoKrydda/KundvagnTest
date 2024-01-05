using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kundvagn
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        public void removeItem(Product product)
        {
            int index = Products.IndexOf(product);

            if (index != -1)
            {
                Products.RemoveAt(index);
                Console.WriteLine("En enhet av produkten har tagits bort från kundvagnen.");
            }
            else
            {
                Console.WriteLine("Produkten finns inte i kundvagnen.");
            }
        }
    }
}
