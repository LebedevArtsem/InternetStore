using System;

namespace InternetStore.Domain;
public class Category
{
    public string Id { get; set; }

    public string Title { get; set; }

    public Category()
    {
        Id = Guid.NewGuid().ToString();
    }
}

