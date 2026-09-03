

using Part3._1;

string[] linesOfFile = File.ReadAllLines("sales.csv");
List<Sale> sales = new List<Sale>();

foreach (string line in linesOfFile.Skip(1))
{
    //  0      1       2     3
    //Date,Employee,Region,Sales
    string[] partsOfLine = line.Split(',');

    Sale s = new Sale();
    s.Date = DateTime.Parse(partsOfLine[0]);
    s.Employee = partsOfLine[1];
    s.Region = partsOfLine[2];
    s.Sales = double.Parse(partsOfLine[3]);

    sales.Add(s);
}


foreach (Sale sale in sales)
{
    Console.WriteLine(sale);
}

double total = TotalSales(sales);
Console.WriteLine($"Total Sales: {total.ToString("C")}");

double average = AverageSales(sales);
Console.WriteLine($"Average Sales: {average.ToString("C")}");

double largest = LargestSale(sales);
//largest = sales.Max(sale => sale.Sales);
Console.WriteLine($"Largest Sale: {largest.ToString("C")}");

File.WriteAllText("sales.txt", $"Total Sales: {total.ToString("C")}\nAverage Sales: {average.ToString("C")}\nLargest Sale: {largest.ToString("C")}");

double LargestSale(List<Sale> sales)
{
    double largest = sales[0].Sales;
    foreach (Sale sale in sales)
    {
        if (sale.Sales > largest)
        {
            largest = sale.Sales;
        }
    }
    return largest;
}

double TotalSales(List<Sale> sales)
{
    double total = 0.0;
    foreach (Sale sale in sales)
    {
        total += sale.Sales;
    }
    return total;
}

double AverageSales(List<Sale> sales)
{
    double total = TotalSales(sales);

    return total / sales.Count;
}