using System;

namespace InternetStore.Models;
public class Category
{
    public string Id { get; set; }

    public string Title { get; set; }

    public Category()
    {
        Id = Guid.NewGuid().ToString();
    }
}

