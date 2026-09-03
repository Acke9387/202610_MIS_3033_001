using System;
using System.Collections.Generic;
using System.Text;

namespace Part3._3
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name {get;set;}
        public string Category {get;set;}
        public double Price {get;set;}

        public Product()
        {
            ProductID = 0;
            Name = string.Empty;
            Category = string.Empty;
            Price = 0;
        }


        public override string ToString()
        {
            return $"ProductID: {ProductID}, Name: {Name}, Category: {Category}, Price: {Price}";
        }

    }
}
