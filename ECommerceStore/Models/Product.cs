﻿namespace ECommerceStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        //public Catagory Catagory { get; set; }
        public string Catagory { get; set; }
        public string Image { get; set; }
    }
}
