using System;

namespace supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerRepository customerRepo = new CustomerRepository();
            while(true)
            {
            customerRepo.SetCustomerOrderDetails();
            LinqOperations linq = new LinqOperations(customerRepo);
            linq.Operations();
            }
        }
    }
}
