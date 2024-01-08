using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kundvagn
{
    public class Product
    {
        public string Name { get; }
        public Brand Brand { get; }
        public double Price { get; }

        public Product(string name, Brand brand, double price)
        {
            Name = name;
            Brand = brand;
            Price = price;
        }
    }
}
