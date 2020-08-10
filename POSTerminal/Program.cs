using System;
using System.Collections.Generic;

namespace POSTerminal
{
    class Program
    {
        public static List<Product> Product()
        {
            //Make list of products 
            List<Product> products = new List<Product>();

            Product One = new Product("Philips Brilliance", "Computers", "49 inch 4K Monitor", 1300m, 10);
            Product Two = new Product("Samsung Laptop", "Computers", "Gaming Laptop", 1500m, 10);
            Product Three = new Product("Dell Laptop", "Computers", "Business Laptop", 1000m, 10);
            Product Four = new Product("Hp Envy Printer", "Computers", "Wireless Printer", 50m, 10);
            Product Five = new Product("Bose Headphones", "Audio", "Wireless Headphones", 400m, 10);
            Product Six = new Product("Asus Monitor", "Computers", "32 inch Monitor", 50m, 10);
            Product Seven = new Product("XBox Controller", "Gaming", "Wireless Controller", 60m, 10);
            Product Eight = new Product("Samsung TV", "Electioncs", "72 inch 4K TV", 1200m, 10);
            Product Nine = new Product("Playstation Pro", "Games", "4K Gaming System", 300m, 10);
            Product Ten = new Product("Nintendo Switch", "Games", "Gaming System", 1500m, 10);
            Product Eleven = new Product("Samsung SoundBar", "Audio", "Bluetooth Speaker", 600m, 10);
            Product Twelve = new Product("Samsung Note 10 plus", "Cellphone", "Smartphone", 1000m, 10);

            products.Add(One);
            products.Add(Two);
            products.Add(Three);
            products.Add(Four);
            products.Add(Five);
            products.Add(Six);
            products.Add(Seven);
            products.Add(Eight);
            products.Add(Nine);
            products.Add(Ten);
            products.Add(Eleven);
            products.Add(Twelve);

            return products;
        }
        public static void ShowProduct(List<Product> products)
        {
            int i = 1;

            foreach (var product in products)
            {
                Console.WriteLine($"{i}.) Name: {product.Name}, Description: {product.Description}, Price: {product.Price}, Quantity; {product.Quantity}");
                i++;
            }           
        }
        public static Product AddToCart(List<Product> list, int name, int quantity)
        {            
            Product product = new Product(list[name - 1].Name, quantity, (int)list[name - 1].Price * quantity);

            return product;
        }
        //public static void ShowCart(List<Product> cartList)
        //{
        //    foreach (var item in cartList)
        //    {
        //        Console.WriteLine($"{item.Name}, {item.Description}, {item.Price}, {item.Quantity}");
        //    }
        //}

        public static decimal PayCash(List<Product> shoppingCart)
        {
            decimal subTotal = 0m, salesTax = 0m, grandTotal = 0m, change = 0m , amount = 0m;
            
            Console.WriteLine();
            
            foreach (Product item in shoppingCart)
            {
                subTotal = Math.Round((((int)item.Quantity * item.Price)), 2, MidpointRounding.ToZero);
                salesTax = Math.Round(((subTotal) * (decimal)0.06), 2, MidpointRounding.ToZero);
            }
            grandTotal = Math.Round(subTotal + salesTax);

           
            Console.WriteLine("You have selected the following items:\n");
            foreach (var product in shoppingCart)
            {
                Console.WriteLine($"{product.Quantity:C2} x {product.Name} @ {product.Price}");

                Console.WriteLine();
            }

            Console.WriteLine($"\nSubtotal: {subTotal:C2)}\n" +
                $"Sales Tax: {salesTax:C2}\n" +
                $"nGrand Total: {grandTotal:C2}\n");

            Console.WriteLine();

            Console.WriteLine($"Grand Total: {grandTotal:C2}\n");

            Console.WriteLine();

            Console.WriteLine("Please enter the amount of cash you would like to apply:");

            amount = Convert.ToDecimal(Console.ReadLine());

            bool doAgain = false;

            do
            {
                if (amount == grandTotal)
                {
                    Console.WriteLine("Paid in full");
                    change = grandTotal - amount;
                    return change;
                }
                else if (amount > grandTotal)
                {
                    change = amount - grandTotal;
                    Console.WriteLine($"Change: {change}");
                    return change;
                }
                else
                {
                    Console.WriteLine("That is not a valid amount.");
                    doAgain = true;
                }

                //change = Payment.PayCash(grandTotal);
            } while (doAgain == true);
            return 0m;
        }

        static void Main(string[] args)
        {
            bool repeat = true;

            List<Product> productsList = Product();
            List<Product> shoppingCart = new List<Product>();

            do
            {
                //List<Product> productsList = Product();
                //List<Product> shoppingCart = new List<Product>();

                Console.WriteLine("Welcome to the store! \n" +
                    "What would you like to buy today?");

                Console.WriteLine();

                ShowProduct(productsList);

                Console.WriteLine();

                if (shoppingCart.Count > 0)
                {
                    int itemsInCart = 0;

                    foreach (var item in shoppingCart)
                    {
                        itemsInCart = itemsInCart + item.Quantity; 
                    }

                    Console.WriteLine($"Current item(s) in cart: {itemsInCart}");
                }
                Console.WriteLine("Add item to your cart by typing in the number to the left of the item");
                int itemSelected = (Convert.ToInt32(Console.ReadLine()) /*productsList.Count + 1)*/);

                
                Console.WriteLine("\nHow many would you like to add?");
                int quantity = Convert.ToInt32(Console.ReadLine());

                
                shoppingCart.Add(AddToCart(productsList, itemSelected, quantity));
                
                Console.WriteLine("Would you like to continue shopping or checkout? Please type in (continue or checkout)");
                string continueShopping = Console.ReadLine().ToLower();
                Console.WriteLine();

                while (continueShopping != "continue" && continueShopping != "checkout")
                {
                    Console.WriteLine("Please enter valid answer");
                    continueShopping = Console.ReadLine().ToLower();
                }
                if (continueShopping == "checkout")
                {
                    repeat = false;
                }
                else if (continueShopping == "continue")
                {

                }

            }while (repeat);

           PayCash(shoppingCart);
        }

       


    }
}
