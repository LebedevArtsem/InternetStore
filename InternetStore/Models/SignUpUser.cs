using System.ComponentModel.DataAnnotations;

namespace InternetStore.Models
{
    public class SignUpUser
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Enter a email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm the password")]
        public string PasswordConfirm { get; set; }

    }
}
