List<Product> products = new List<Product>();
Order order = new Order();
order.OrderID = 1;
start:
do
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("To enter a new product - followthe step -    To quit enter:'Q'");
    Console.ResetColor();

    Console.Write("Enter Category: ");
    string input = Console.ReadLine();
    if (input.Trim().ToUpper() == "Q")
    {
        break;
    }
    string category = input.Trim();

    Console.Write("Enter Product Name: ");
    input = Console.ReadLine();
    if (input.Trim().ToUpper() == "Q")
    {
        break;
    }
    string productName = input.Trim();

    do
    {
        Console.Write("Enter Price: ");
        input = Console.ReadLine();
        if (input.Trim().ToUpper() == "Q")
        {
            break;
        }
        if (!decimal.TryParse(input.Trim(), out decimal price) || price < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid price. Please enter a valid positive number.");
            Console.ResetColor();
            continue;
        }
        else { break; }

    } while (true);
    decimal validPrice = decimal.Parse(input.Trim());

    Product product = new Product(category, productName, validPrice);


    products.Add(product);
    order.Products = products;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Product added successfully!");
    Console.ResetColor();
    Console.WriteLine("------------------------------------------------");




} while (true);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Category".PadRight(15) + "Product".PadRight(15) + "Price");
Console.ResetColor();
foreach (var product in order.Products)
{
    Console.WriteLine(product.Category.ToString().PadRight(15) +
        product.Name.ToString().PadRight(15) + product.Price);
}
Console.WriteLine(String.Empty.PadRight(15) + "Totalamount:".PadRight(15) + order.Products.Sum(p => p.Price));
Console.WriteLine("------------------------------------------------");

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("To enter a new product - enter 'P' | To search for a product - enter 'S'| To quit enter 'Q'");
Console.ResetColor();

do
{
    string input = Console.ReadLine();
    if (input.Trim().ToUpper() == "Q") { break; }
    if (input.Trim().ToUpper() == "P") { goto start; }

    if (input.Trim().ToUpper() == "S")
    {

        Console.Write("Enter Product Name to search: ");
        string searchInput = Console.ReadLine();
        if (searchInput.Trim().ToUpper() == "Q") { break; }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Category".PadRight(15) + "Product".PadRight(15) + "Price");
        Console.ResetColor();

        Product searchProduct = order.Products.FirstOrDefault(p => p.Name == searchInput);
        foreach (var product in order.Products)
        {
            if (searchProduct.Name == product.Name)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(product.Category.ToString().PadRight(15) +
                product.Name.ToString().PadRight(15) + product.Price);
                Console.ResetColor();
                continue;
            }
            Console.WriteLine(product.Category.ToString().PadRight(15) +
                product.Name.ToString().PadRight(15) + product.Price);
        }
        Console.WriteLine(String.Empty.PadRight(15) + "Totalamount:".PadRight(15) + order.Products.Sum(p => p.Price));
        Console.WriteLine("------------------------------------------------");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("To enter a new product - enter 'P' | To search for a product - enter 'S'| To quit enter 'Q'");
        Console.ResetColor();

    }


} while (true);


class Product
{
    public string Category { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Product(string category, string name, decimal price)
    {
        Category = category;
        Name = name;
        Price = price;
    }
}
class Order
{
    public int OrderID { get; set; }
    public List<Product> Products { get; set; }
}