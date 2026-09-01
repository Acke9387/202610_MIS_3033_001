using Part2._4;

List<Customer> customers = new List<Customer>
{
    new Customer { CustomerID = 1, Name = "Alice", Email = "alice@example.com" },
    new Customer { CustomerID = 2, Name = "Bob", Email = "bob@example.com" },
    new Customer { CustomerID = 3, Name = "Charlie", Email = "charlie@example.com" }
};  

List<Order> orders = new List<Order>
{
    new Order { OrderID = 101, CustomerID = 1, OrderDate = DateTime.Now.AddDays(-5), Total = 150.75 },
    new Order { OrderID = 102, CustomerID = 2, OrderDate = DateTime.Now.AddDays(-3), Total = 200.00 },
    new Order { OrderID = 103, CustomerID = 1, OrderDate = DateTime.Now.AddDays(-1), Total = 50.25 }
};

Console.WriteLine("CUSTOMERS");
foreach (var customer in customers)
{
    Console.WriteLine(customer);
}

Console.WriteLine("Which customer do you want to view orders for? Please enter their ID: ");
int customerId = int.Parse(Console.ReadLine());

Console.WriteLine("ORDERS for Customer ID: " + customerId);
bool customerHasAnOrder = false;
foreach (var order in orders)
{
    if (order.CustomerID == customerId)
    {
        Console.WriteLine(order);
        customerHasAnOrder = true;
    }
}

if (!customerHasAnOrder)
{
    Console.WriteLine("No orders found for this customer.");
}
