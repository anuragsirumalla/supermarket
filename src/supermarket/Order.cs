using System;
using System.Collections.Generic;

namespace supermarket
{
    class Order
    {
        public int NoOfItems
        {
            get;
            set;
        }
        public Product Product;
        public Order(int NoOfItems, Product product)
        {
            this.NoOfItems = NoOfItems;
            this.Product = product;
        }
    }
}