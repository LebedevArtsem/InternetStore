
using System;
using System.ComponentModel.DataAnnotations;

namespace InternetStore.Models
{
    public class SignInUser
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Enter a email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        public string Password { get; set; }

        public SignInUser()
        {

        }

        public SignInUser(string email,string password)
        {
            Email = email;
            Password = password;
        }
    }
}
