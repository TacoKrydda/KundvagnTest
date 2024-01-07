

// Skapa några varumärken
Brand apple = new Brand("Juliet");
Brand orange = new Brand("Cuties");

// Skapa några produkter och tilldela dem varumärken
Product appleProduct = new Product("Apple", apple, 2.5);
Product orangeProduct = new Product("Orange", orange, 1.8);

// Skapa en lista med produkter
List<Product> products = new List<Product> { appleProduct, orangeProduct };

// Skapa en kundvagn
Cart cart = new Cart();

bool loop = true;

do
{
    Console.Clear();
    

    Console.WriteLine("Välj en åtgärd:");
    Console.WriteLine("1.Lägg till frukt i kundvagnen\n2.Ta bort frukt från kundvagnen\n3.Visa kundvagnen och totalpris\nAvsluta");

    int userInput = int.Parse(Console.ReadLine());
    switch (userInput)
    {
        case 1:
            // Visa produktlistan för användaren
            Console.WriteLine("Välj en produkt att lägga till i kundvagnen:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Brand.Name} - {products[i].Name} - {products[i].Price} kr");
            }

            // Låt användaren välja en produkt
            Console.Write("Ange produktens nummer: ");
            int selectedProductIndex = int.Parse(Console.ReadLine()) - 1;

            // Lägg till produkten i kundvagnen
            cart.AddToCart(products[selectedProductIndex]);
            Console.WriteLine($"{products[selectedProductIndex].Name} har lagt till i kundvagnen\nTryck enter för att fortsätta");
            Console.ReadKey();
            break;
        case 2:
            // Ta bort en produkt från kundvagnen
            Console.Write("Ange produktnummer att ta bort: ");
            int productToRemoveIndex = int.Parse(Console.ReadLine()) - 1;
            cart.RemoveFromCart(cart.CartItems[productToRemoveIndex].Product);
            Console.ReadKey();
            break;
        case 3:
            // Visa kundvagnen
            Console.WriteLine("Kundvagnen:");
            foreach (CartItem cartItem in cart.CartItems)
            {
                Console.WriteLine($"{cartItem.Product.Brand.Name} - {cartItem.Product.Name} - {cartItem.Quantity}st - {cartItem.Quantity * cartItem.Product.Price} kr");
            }
            // Beräkna och visa totalpriset för alla produkter i kundvagnen
            double totalCartPrice = cart.CartItems.Sum(item => item.Quantity * item.Product.Price);
            Console.WriteLine($"Totalt pris för alla produkter i kundvagnen: {totalCartPrice} kr");
            Console.ReadKey();
            break;
        case 4:
            loop = false;
            break;
        default:
            Console.WriteLine("???");
            break;
    }
    

    

} while (loop);


// Brand-klassen
class Brand
{
    public string Name { get; }

    public Brand(string name)
    {
        Name = name;
    }
}

// Product-klassen
class Product
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

// CartItem-klassen
class CartItem
{
    public Product Product { get; }
    public int Quantity { get; set; }

    public CartItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }
}

// Cart-klassen
class Cart
{
    public List<CartItem> CartItems { get; }

    public Cart()
    {
        CartItems = new List<CartItem>();
    }

    public void AddToCart(Product product)
    {
        CartItem existingItem = CartItems.Find(item => item.Product == product);

        if (existingItem != null)
        {
            existingItem.Quantity++;
            
        }
        else
        {
            CartItems.Add(new CartItem(product, 1));
        }
    }

    public void RemoveFromCart(Product product)
    {
        CartItem existingItem = CartItems.Find(item => item.Product == product);

        if (existingItem != null)
        {
            if (existingItem.Quantity > 1)
            {
                existingItem.Quantity--;
            }
            else
            {
                CartItems.Remove(existingItem);
            }
        }
    }
}
