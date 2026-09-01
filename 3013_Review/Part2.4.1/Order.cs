using System;
using System.Collections.Generic;
using System.Text;

namespace Part2._4._1
{
    public class Order
    {
        public int OrderID { get;set; } 
        public Customer  Customer { get;set;  }
        public DateTime OrderDate { get;set;  }
        public double Total { get;set; }

        public Order()
        {
            OrderID = 0;
            Customer = new Customer();
            OrderDate = DateTime.Now;
            Total = 0.0;
        }

        public override string ToString()
        {
            return $"Order ID: {OrderID}, Customer: {Customer}, Order Date: {OrderDate.ToShortDateString()}, Total: ${Total:F2}";
        }
    }
}
