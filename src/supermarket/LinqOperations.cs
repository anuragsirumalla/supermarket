using System;
using System.Collections.Generic;
using System.Linq;

namespace supermarket
{
    class LinqOperations
    {
        CustomerRepository customerRepository;
        public LinqOperations(CustomerRepository repo)
        {
            customerRepository = repo;
        }
        public IEnumerable<Customer> GetCustomers()
        {
            var allCustomers = from customer in customerRepository.customersList select customer;
            return allCustomers;
        }
        public IEnumerable<Customer> GetCustomer(string customerName)
        {
            var customerOrderCount = from customer in customerRepository.customersList
                                     where customer.Name == customerName
                                     select customer;
            return customerOrderCount;
        }
        public decimal TotalRevenueOfCompany()
        {
            var totalRevenue =
                (from c in customerRepository.customersList
                 select c.ordersList.Sum(order => order.Product.Cost * order.NoOfItems)).Sum();
            return totalRevenue;
        }
        public IEnumerable<string> GetConsolidatedBillOfCustomers()
        {
            var consolidatedBill = from c in customerRepository.customersList
                                   let sum = c.ordersList.Sum(order => order.Product.Cost * order.NoOfItems)
                                   select c.Name + " " + sum;
            return consolidatedBill;
        }
        public IEnumerable<String> particularProductCustomers(string productName)
        {
            var productCustomers = customerRepository.customersList.Where(customer => customer.ordersList.Any(order => order.Product.Name == productName)).Select(customer => customer.Name);
            return productCustomers;
        }

        public decimal SumOfProducts(List<Order> ordersList)
        {
            decimal totalSum = 0;
            foreach (Order order in ordersList)
            {
                decimal cost = order.Product.Cost;
                int totalItems = order.NoOfItems;
                totalSum = totalSum + (cost * totalItems);
            }
            return totalSum;
        }
        public void Operations()
        {
            Console.WriteLine("   Statistics of InnRoad SuperMarket ");
            string status = "yes";
            while (status.Equals("yes"))
            {
                Console.WriteLine("\n1.Customers Data   2.Customers Bill  3.Total Revenue of Company    4.Total Customers and Bill Amount    5.Particular product customers      6.Exit");
                Console.Write("Enter your choice : ");
                int choice = Convert.ToUInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        var customers = GetCustomers();
                        Console.WriteLine("\n\n{0,10}{1,18}{2,18}", "Name", "State", "PhoneNumber");
                        foreach (Customer EachCustomer in customers)
                        {
                            Console.WriteLine("{0,10}{1,18}{2,18}", EachCustomer.Name, EachCustomer.State, EachCustomer.PhoneNumber);
                        }
                        break;
                    case 2:
                        Console.Write("Enter name of the customer : ");
                        string name = Console.ReadLine();
                        var customer = GetCustomer(name);
                        Console.WriteLine("\n\n{0,12}{1,12}{2,10}", "Product Name", "Cost", "Total Cost");
                        foreach (Customer orderCustomer in customer)
                        {

                            foreach (Order order in orderCustomer.ordersList)
                            {
                                Console.WriteLine("{0,12}{1,12}{2,10}", order.Product.Name, order.Product.Cost, order.NoOfItems * order.Product.Cost);
                            }
                            Console.WriteLine("Total Amount :  {0} ", SumOfProducts(orderCustomer.ordersList));
                        }
                        break;
                    case 3:
                        Console.WriteLine("Total Revenue of company : {0}", TotalRevenueOfCompany());
                        break;
                    case 4:
                        var totalCustomers = GetConsolidatedBillOfCustomers();
                        if (totalCustomers.ToList().Count > 0)
                        {
                            foreach (var EachCustomer in totalCustomers)
                            {
                                Console.WriteLine(EachCustomer);
                            }
                        }
                        else
                            Console.WriteLine("No Customers !");

                        break;
                    case 5:
                        Console.Write("Enter the product name to find customers   :   ");
                        string productName = Console.ReadLine().Trim();
                        var particularCustomers = particularProductCustomers(productName);
                        if (particularCustomers.ToList().Count > 0)
                        {
                            foreach (var EachCustomer in particularCustomers)
                            {
                                Console.WriteLine(EachCustomer);
                            }
                        }
                        else
                            Console.WriteLine("No Customers on particular product!");

                        break;
                    case 6:
                        status = "false";
                        break;
                }
            }
        }

    }
}