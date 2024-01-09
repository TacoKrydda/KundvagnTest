namespace Kundvagn
{
    public class ShoppingCartApp
    {
        private List<Product> products;
        private Cart cart;

        public ShoppingCartApp()
        {
            // Initialize products and cart
            Brand apple = new Brand("Juliet");
            Brand orange = new Brand("Cuties");

            Product appleProduct = new Product("Apple", apple, 2.5);
            Product orangeProduct = new Product("Orange", orange, 1.8);

            products = new List<Product> { appleProduct, orangeProduct };
            cart = new Cart();
        }

        public void Run()
        {
            bool loop = true;

            do
            {
                Console.Clear();

                Console.WriteLine("Välj en åtgärd:");
                Console.WriteLine("1. Lägg till frukt i kundvagnen\n2. Ta bort frukt från kundvagnen\n3. Visa kundvagnen och totalpris\n4. Avsluta");

                int userInput;
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            AddProductToCart();
                            break;
                        case 2:
                            RemoveProductFromCart();
                            break;
                        case 3:
                            DisplayCart();
                            break;
                        case 4:
                            loop = false;
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val. Försök igen.");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning. Vänligen ange ett heltal.");
                    Console.ReadKey();
                }
            } while (loop);
        }

        private void AddProductToCart()
        {
            bool loop = true;
            Console.WriteLine("Välj en produkt att lägga till i kundvagnen:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Brand.Name} - {products[i].Name} - {products[i].Price} kr");
            }
            do
            {
                Console.Write("Ange produktens nummer: ");
                int selectedProductIndex;
                if (int.TryParse(Console.ReadLine(), out selectedProductIndex) && selectedProductIndex > 0 && selectedProductIndex <= products.Count)
                {
                    Console.Write("Ange antal av {0} att lägga till: ", products[selectedProductIndex - 1].Name);
                    int quantityToAdd;
                    if (int.TryParse(Console.ReadLine(), out quantityToAdd) && quantityToAdd > 0)
                    {
                        cart.AddToCart(products[selectedProductIndex - 1], quantityToAdd);
                        Console.WriteLine($"{quantityToAdd}st {products[selectedProductIndex - 1].Brand.Name} {products[selectedProductIndex - 1].Name} har lagt till i kundvagnen\nTryck enter för att fortsätta");
                        loop = false;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt antal. Var vänlig ange ett positivt heltal.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt produktval. Försök igen.");
                    Console.ReadKey();
                }
            } while (loop);
            
        }

        private void RemoveProductFromCart()
        {
            bool loop = true;
            Console.Write("Ange produktnummer att ta bort: ");
            do
            {
                int productToRemoveIndex;
                if (int.TryParse(Console.ReadLine(), out productToRemoveIndex) && productToRemoveIndex > 0 && productToRemoveIndex <= cart.CartItems.Count)
                {
                    Console.Write($"Ange antal av {cart.CartItems[productToRemoveIndex - 1].Product.Name} att ta bort: ");
                    int quantityToRemove;
                    if (int.TryParse(Console.ReadLine(), out quantityToRemove) && quantityToRemove > 0)
                    {
                        cart.RemoveFromCart(cart.CartItems[productToRemoveIndex - 1].Product, quantityToRemove);
                        Console.WriteLine("Produkt har tagits bort från kundvagnen\nTryck enter för att fortsätta");
                        loop = false;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt antal. Var vänlig ange ett positivt heltal.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt produktnummer. Försök igen.");
                }
            } while (loop);
            
        }

        private void DisplayCart()
        {
            Console.WriteLine("Kundvagnen:");
            foreach (CartItem cartItem in cart.CartItems)
            {
                Console.WriteLine($"{cartItem.Product.Brand.Name} - {cartItem.Product.Name} - {cartItem.Quantity}st - {cartItem.Quantity * cartItem.Product.Price} kr");
            }

            double totalCartPrice = cart.CalculateTotalPrice();
            Console.WriteLine($"Totalt pris för alla produkter i kundvagnen: {totalCartPrice} kr");
            Console.ReadKey();
        }
    }
}
