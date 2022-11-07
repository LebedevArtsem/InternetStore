using System;

namespace InternetStore.Domain;
public class User
{
    public string Id { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public string Password { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string Permission { get; set; }

    public User()
    {
        Id = Guid.NewGuid().ToString();
    }

    public User(string email, string name, string password)
    {
        Id = Guid.NewGuid().ToString();
        Email = email;
        Password = password;
        Firstname = name;
        Permission = "User";
    }
}

