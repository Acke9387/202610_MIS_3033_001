using System;
using System.Collections.Generic;
using System.Text;

namespace Part2._2
{
    public class Employee
    {

        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }

        /// <summary>
        /// Initializes a new instance of the Employee class with default values.
        /// </summary>
        public Employee()
        {
            EmployeeID = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            HourlyRate = 0.0;
            HoursWorked = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        /// <summary>
        /// Calculates the gross pay for the employee based on their hourly rate and hours worked, including overtime pay if applicable.
        /// </summary>
        /// <returns></returns>
        public double CalculateGrossPay()
        {
            double pay = 0.0;

            if (HoursWorked > 40)
            {
                int overtimeHours = HoursWorked - 40;
                pay = (40 * HourlyRate) + (overtimeHours * HourlyRate * 1.5);
            }
            else
            {
                pay = HoursWorked * HourlyRate;
            }

            return pay;
        }


    }
}
