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
