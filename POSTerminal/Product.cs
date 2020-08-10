using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminal
{
    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }


        public Product()
        {

        }
        public Product (string name, string category, string description, decimal price, int quantity)
        {
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        public Product(string name, decimal price, int quantity)
        {
            Name = name;            
            Price = price;
            Quantity = quantity;
        }




    }
}
