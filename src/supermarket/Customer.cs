using System;
using System.Collections.Generic;

namespace supermarket
{
    class Customer
    {
        public string Name
        {
            get;
            set;
        }
        public string State
        {
            get;
            set;
        }
        public long PhoneNumber
        {
            get;
            set;
        }

        public List<Order> ordersList;
        public Customer()
        {

        }
        public Customer(string Name, string State, long PhoneNumber, List<Order> order)
        {
            this.Name = Name;
            this.State = State;
            this.PhoneNumber = PhoneNumber;
            this.ordersList = order;
        }
        public List<Order> SetOrderDetails()
        {
            ordersList = new List<Order>();
            Console.WriteLine("\n      Order Details");
            char choice = 'y';
            while (choice == 'y')
            {
                Console.WriteLine("\nProduct Details ");
                Product newProduct = SetProductDetails();
                Console.Write("Enter number of quantity  :  ");
                int noOfItems = Convert.ToInt16(Console.ReadLine());
                ordersList.Add(new Order(noOfItems, newProduct));
                Console.WriteLine("Do you want to add products? y/n ");
                choice = Convert.ToChar(Console.ReadLine());
            }
            return ordersList;
        }
        public Product SetProductDetails()
        {
            Console.Write("Enter Name of the Product :  ");
            string productName = Console.ReadLine().Trim();
            Console.Write("Enter cost of the Product  :  ");
            decimal cost = Convert.ToDecimal(Console.ReadLine());
            return new Product(productName, cost);
        }

    }
}