using InternetStore.Models;
using System;
using System.Collections.Generic;

namespace InternetStore.Domain
{
    public class Cart
    {
        public string Id { get; set; }

        public User User { get; set; }

        public List<ProductCart> Products { get; set; }

        public Cart()
        {
            Id = Guid.NewGuid().ToString();
            Products = new List<ProductCart>();
        }
    }
}
