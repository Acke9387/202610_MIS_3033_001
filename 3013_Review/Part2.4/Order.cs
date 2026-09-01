using System;
using System.Collections.Generic;
using System.Text;

namespace Part2._4
{
    public class Order
    {
        public int OrderID { get;set; } 
        public int  CustomerID { get;set;  }
        public DateTime OrderDate { get;set;  }
        public double Total { get;set; }

        public Order()
        {
            OrderID = 0;
            CustomerID = 0;
            OrderDate = DateTime.Now;
            Total = 0.0;
        }

        public override string ToString()
        {
            return $"Order ID: {OrderID}, Customer ID: {CustomerID}, Order Date: {OrderDate.ToShortDateString()}, Total: ${Total:F2}";
        }
    }
}
