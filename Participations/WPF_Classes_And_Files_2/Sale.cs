using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Classes_And_Files_2
{
    public class Sale
    {

        public DateTime TransactionDate { get; set; }
        public double Price { get; set; }
        public string PaymentType { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        //default constructor / empty constructor
        public Sale()
        {
            TransactionDate = DateTime.Now;
            Price = 0.0;
            PaymentType = string.Empty;
            Name = string.Empty;
            Country = string.Empty;
        }

        public Sale(double price, string pType) : this()
        {
            TransactionDate = DateTime.Now;
            Name = string.Empty;
            Country = string.Empty;
            Price = price;
            PaymentType = pType;
        }


        public override string ToString()
        {
            return $"{PaymentType[0]} {Name} - {Price.ToString("C")}";
        }

    }
}
