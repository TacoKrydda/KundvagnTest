using Kundvagn;

Console.WriteLine("Hello");
bool loop = false;
var cartItems = new CartItem();
var item1 = new Product { ProductId = 1, BrandId = 1, ProductName = "Melon" };
var item2 = new Product { ProductId = 2, BrandId = 2, ProductName = "Banan" };
do
{
    Console.WriteLine("Buy\n1.Melon\n2.Apple");
	var userInput = int.Parse(Console.ReadLine());
	switch (userInput)
	{
        case 1:
            Console.WriteLine("Melon");
            cartItems.Products.Add(item1);
            break;
        case 2:
            Console.WriteLine("Banan");
            cartItems.Products.Add(item2);
            break;
        default:
			break;
	}
    Console.WriteLine("Buy more");
    var shopmore = int.Parse(Console.ReadLine());
    if (shopmore == 1)
    {
        loop = true;
    }
    else if(shopmore == 2)
    {
        loop = false;
    }
} while (loop);


foreach (var item in cartItems.Products)
{
    Console.WriteLine(item.ProductName);
}