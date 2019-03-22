using System.ComponentModel.DataAnnotations;

namespace Fit4You.WebApp.Models
{
    public class SignUpModel
    {
        [EmailAddress(ErrorMessage = "This is not an email address")]
        [Required(ErrorMessage = "Enter your email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter your password again")]
        [Compare("Password", ErrorMessage = "Password does not match")]
        public string RepeatPassword { get; set; }
    }
}
