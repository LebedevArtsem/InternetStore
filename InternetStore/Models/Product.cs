using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetStore.Models
{
    public class Product
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Size { get; set; }

        public string Image { get; set; }

        public int Price { get; set; }

        public int Rate { get; set; }

        public Category Category { get; set; }

        public User User { get; set; }

        public Product()
        {
            Id = Guid.NewGuid().ToString();
        }

    }
}
