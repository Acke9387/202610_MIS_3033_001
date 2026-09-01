using System;
using System.Collections.Generic;
using System.Text;

namespace Part2._4._1
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name {  get; set; }
        public string Email { get; set;  }

        public Customer()
        {
            CustomerID = 0;
            Name = string.Empty;
            Email = string.Empty;
        }

        public override string ToString()
        {
            return $"{Name} [{CustomerID}] - {Email}";  
        }

    }
}
