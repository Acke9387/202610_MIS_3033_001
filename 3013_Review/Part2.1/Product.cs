using System;
using System.Collections.Generic;
using System.Text;

namespace Part2._1
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set;  }
        private int QuantityInStock;

        /// <summary>
        /// Initializes a new instance of the Product class with default values.
        /// </summary>
        public Product()
        {
            ProductID = 0;
            Name = string.Empty;
            Price = 0.0;
            QuantityInStock = 0;
        }

        public Product(int id, string name, double price, int quantity)
        {
            ProductID = id;
            Name = name;
            Price = price;
            QuantityInStock = quantity;
        }

        public int GetInventoryValue()
        {
            return QuantityInStock;
        }

        /// <summary>
        /// Determines whether the product is low in stock based on the quantity in stock.
        /// </summary>
        /// <returns>true if the product is low in stock; otherwise, false.</returns>
        public bool IsLowStock()
        {
            if (QuantityInStock <= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"Product ID: {ProductID}, Name: {Name}, Price: {Price:C}, Quantity in Stock: {QuantityInStock}";
        }

    }
}
