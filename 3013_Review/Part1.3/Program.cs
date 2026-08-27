/*
  Username Generator
Ask the user for:

First name
Last name
Graduation year
Create a method that generates a username.

Example:

First Name: Adam
Last Name: Ackerman
Graduation Year: 2027

Username: aackerman27
Then validate that the user entered:

A first name
A last name
A four-digit graduation year
 */

string firstName, lastName;
int graduationYear;

Console.WriteLine("Please enter your first name:");
firstName = Console.ReadLine();
Console.WriteLine("Please enter your last name:");
lastName = Console.ReadLine();
Console.WriteLine("Please enter your four-digit graduation year:");
string graduationYearString = Console.ReadLine();
while (int.TryParse(graduationYearString, out graduationYear) == false || graduationYear < 1920 || graduationYear > 2050)
{
    Console.WriteLine("Please enter a valid four-digit graduation year.");
    graduationYearString = Console.ReadLine();
}

while (firstName.Trim().Length == 0)
{
    Console.WriteLine("Please enter a valid first name.");
    firstName = Console.ReadLine();
}

while (lastName.Trim().Length == 0)
{
    Console.WriteLine("Please enter a valid last name.");
    firstName = Console.ReadLine();
}
//substring:
//0123
//2020
string userName = $"{firstName.ToLower()[0]}{lastName.ToLower()}{graduationYear.ToString().Substring(2)}";

Console.WriteLine(userName);