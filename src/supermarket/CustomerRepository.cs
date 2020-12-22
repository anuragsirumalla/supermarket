using System;
using System.Collections.Generic;

namespace supermarket
{
    class CustomerRepository
    {
        public List<Customer> customersList;
        public CustomerRepository()
        {
            customersList = new List<Customer>();
        }

        public void SetCustomerOrderDetails()
        {
            Console.WriteLine("Hey! Please Enter Customer Details");
            Console.Write("Enter customer's Name : ");
            String name = Console.ReadLine();
            Console.Write("Enter customer's State : ");
            String state = Console.ReadLine();
            Console.Write("Enter customer's PhoneNumber : ");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());
            Customer customer = new Customer();
            List<Order> ordersList = customer.SetOrderDetails();
            customersList.Add(new Customer(name, state, phoneNumber, ordersList));
        }

    }
}