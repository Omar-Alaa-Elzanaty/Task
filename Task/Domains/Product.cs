﻿namespace Tasks.Domains
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<CustomerProduct> Customers { get; set; }
    }
}
