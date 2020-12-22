namespace supermarket
{
    class Product
    {
        public string Name
        {
            get;
            set;
        }
        public decimal Cost
        {
            get;
            set;
        }
        public Product(string Name, decimal Cost)
        {
            this.Name = Name;
            this.Cost = Cost;
        }
    }

}
