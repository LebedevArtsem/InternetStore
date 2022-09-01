using InternetStore.Models;
using System;
using System.Collections.Generic;

namespace InternetStore.Domain;
public class Product
{
    public string Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Image { get; set; }

    public int Price { get; set; }

    public int Rate { get; set; }

    public Dictionary<string, int> Sizes { get; set; }

    public Category Category { get; set; }

    public Product()
    {
        Id = Guid.NewGuid().ToString();
        Sizes = new Dictionary<string, int> { { "XS", 0 }, { "S", 0 }, { "M", 0 }, { "L", 0 }, { "XL", 0 }, { "XLL", 0 } };
    }
}

