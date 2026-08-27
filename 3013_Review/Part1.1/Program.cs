/*
 * Create a console application that calculates the shipping charge for an online order.

    Inputs    
        Order subtotal
        Customer type: Standard or Premium
        Expedited shipping: Yes/No
        Rules
    
    Orders $75+ receive free standard shipping.
    Otherwise, standard shipping costs $7.99.
    Premium customers always receive free standard shipping.
    Expedited shipping adds $12.00 regardless of customer type.
    Sales tax is 8.5%.
    
    Output
    Display:
    
    Subtotal
    Shipping
    Tax
 * 
 * 
 */

double subtotal = 0;
string customerType = "";
string expeditedShipping = "";
double shipping = 0;
double tax = 0;

Console.WriteLine("What is your subtotal? <<");
string strSubtotal = Console.ReadLine();
//subtotal = Convert.ToDouble(strSubtotal);
//subtotal = double.Parse(strSubtotal);

bool isValidNumber = double.TryParse(strSubtotal, out subtotal);

if (isValidNumber  == false)
{
    Console.WriteLine("Sorry, your subtotal has to be a valid number.\nPlease try again<<");
    subtotal = double.Parse(Console.ReadLine());
}

Console.WriteLine("What is your customer type? (Standard or Premium) <<");
customerType = Console.ReadLine();

Console.WriteLine("Do you want expedited shipping? (Yes/No) <<");
expeditedShipping = Console.ReadLine();

if(expeditedShipping.ToLower() == "yes")
{
    shipping = 12.00;
}
else if( customerType.ToLower() == "premium")
{
    shipping = 0;
}
else if (subtotal >= 75)
{
    shipping = 0;
}
else
{
    shipping = 7.99;
}

double total = subtotal + shipping;
tax = total * 0.085;
total += tax;
//total = total + tax;

Console.WriteLine($"Subtotal:\t{subtotal.ToString("C3")}\nShipping:\t{shipping:C3}\nTax:\t\t{tax:C}\nTotal:\t\t{total.ToString("C3")}");