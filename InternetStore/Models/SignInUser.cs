
using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace InternetStore.Models;
public class SignInUser
{
    public string Id { get; set; }

    public string Email { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public SignInUser()
    {

    }

    public SignInUser(string email, string password)
    {
        Email = email;
        Password = password;
    }
}

public class SignInUserValidation : AbstractValidator<SignInUser>
{
    public SignInUserValidation()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Enter a login");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Wrong login");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Enter a password");
    }
}

