using Part2._2;

List<Employee> employees = new List<Employee>();

employees.Add(new Employee { EmployeeID = 1, FirstName = "John", LastName = "Doe", HourlyRate = 20.0, HoursWorked = 45 });
employees.Add(new Employee { EmployeeID = 2, FirstName = "Jane", LastName = "Smith", HourlyRate = 25.0, HoursWorked = 38 });
employees.Add(new Employee { EmployeeID = 3, FirstName = "Bob", LastName = "Johnson", HourlyRate = 30.0, HoursWorked = 50 });
employees.Add(new Employee { EmployeeID = 4, FirstName = "Alice", LastName = "Williams", HourlyRate = 22.0, HoursWorked = 42 });

double totalPay = 0;

foreach (Employee employee in employees)
{
    totalPay += employee.CalculateGrossPay();
}

Console.WriteLine($"Total gross pay for all employees: {totalPay.ToString("C")}");