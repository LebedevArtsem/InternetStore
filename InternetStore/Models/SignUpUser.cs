using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace InternetStore.Models;
public class SignUpUser
{
    public string Id { get; set; }

    public string Email { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public string PasswordConfirm { get; set; }

}

public class SignUpUserValidator : AbstractValidator<SignUpUser>
{
    public SignUpUserValidator()
    {
        RuleFor(c => c.Email).NotEmpty().WithMessage("Enter a email");
        RuleFor(c => c.Email).EmailAddress().WithMessage("Wrong login");
        RuleFor(c => c.Name).NotEmpty().WithMessage("Wrong name");
        RuleFor(c => c.Password).NotEmpty().WithMessage("Enter a password");
        RuleFor(c => c.PasswordConfirm).NotEmpty().WithMessage("Confirm the password");

        RuleFor(x => x).Must(x => x.PasswordConfirm == x.Password).WithMessage("Passwords do not match");
    }
}

