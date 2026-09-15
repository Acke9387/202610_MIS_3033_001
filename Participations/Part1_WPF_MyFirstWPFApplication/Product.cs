using System;
using System.Collections.Generic;
using System.Text;

namespace Part1_WPF_MyFirstWPFApplication
{
    public class Product
    {

        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

        public Product()
        {
            Name = string.Empty;
            Category = string.Empty;
            Price = 0.0;
        }


        public override string ToString()
        {
            return $"{Name} - {Category} - {Price.ToString("C")}";
        }

    }
}
