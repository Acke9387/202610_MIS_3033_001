using System;
using System.Collections.Generic;
using System.Text;

namespace Part3._1
{
    public class Sale
    {
        public DateTime Date { get; set; }
        public string Employee { get; set; }
        public string Region { get; set; }
        public double Sales { get; set; }

        public Sale()
        {
            Date = DateTime.MinValue;
            Employee = string.Empty;
            Region = string.Empty;
            Sales = 0.0;
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()}, {Employee}, {Region}, {Sales}";
        }
    }
}
