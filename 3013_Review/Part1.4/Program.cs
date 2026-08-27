/*
 *Allow the user to repeatedly enter:

Product name
Price
Quantity
Continue until they enter "done".

At the end, display
 */

List<string> productNames = new List<string>();
List<double> productPrices = new List<double>();
List<double> productQuantities = new List<double>();

string status = string.Empty;

while (status.ToLower() != "done")
{
    Console.WriteLine("Enter product name");
    productNames.Add(Console.ReadLine());

    Console.WriteLine("Enter product price");
    productPrices.Add(double.Parse(Console.ReadLine()));

    Console.WriteLine("Enter product quantity");
    productQuantities.Add(double.Parse(Console.ReadLine()));

    Console.WriteLine("Enter 'done' to finish or any other key to continue");
    status = Console.ReadLine();
}

for (int i = 0; i < productNames.Count; i++)
{
    Console.WriteLine($"Product: {productNames[i]}, Price: {productPrices[i]}, Quantity: {productQuantities[i]}, Total: {productPrices[i] * productQuantities[i]}");
}