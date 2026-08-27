/*
 * A salesperson enters their sales totals for the last five days.

    Store the values in a List<double> and calculate:

    Total sales
    Average daily sales
    Highest sales day
    Lowest sales day
    Number of days exceeding $1,000
 */

List<double> salesTotals = new List<double>();

for (int i = 1; i <= 5; i++)
{
    Console.Write($"Enter sales total for day {i}: ");
    double sales = Convert.ToDouble(Console.ReadLine());
    salesTotals.Add(sales);
}

double total = TotalSales(salesTotals);
double average = AverageSales(salesTotals);
double highestSales = HighestSale(salesTotals);
double lowestSales =  LowestSale(salesTotals);
int daysHigherThan1000 = CountDaysAboveThreshold(salesTotals);
int daysHigherThan1500 = CountDaysAboveThreshold(salesTotals, 1500);

Console.WriteLine($"Total sales: {total}");
Console.WriteLine($"Average daily sales: {average}");
Console.WriteLine($"Highest sales day: {highestSales}");
Console.WriteLine($"Lowest sales day: {lowestSales}");
Console.WriteLine($"Days with sales above $1,000: {daysHigherThan1000}");
Console.WriteLine($"Days with sales above $1,500: {daysHigherThan1500}");

int CountDaysAboveThreshold(List<double> sales, double threshold = 1000)
{
    int count = 0;
    foreach (double sale in sales)
    {
        if (sale > threshold)
        {
            count++;
        }
    }
    return count;
}

double LowestSale(List<double> r)
{
    return r.Min();
}
double HighestSale(List<double> q)
{
    double highest = q[0];
    foreach (double sales in q)
    {
        if (sales > highest)
        {
            highest = sales;
        }
    }
    return highest;
}
double AverageSales(List<double> y)
{
    double total = TotalSales(y);
    return total / y.Count;
}
double TotalSales(List<double> x)
{
    double total = 0;
    foreach (double sales in x)
    {
        total += sales;
    }
    return total;
}