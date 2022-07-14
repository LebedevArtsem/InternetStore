using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace InternetStore.Models;
public class User
{
    [BsonId]
    public string Id { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public string Password { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public User()
    {
        Id = Guid.NewGuid().ToString();
    }

    public User(string email, string password)
    {
        Id = Guid.NewGuid().ToString();
        Email = email;
        Password = password;
    }
}
