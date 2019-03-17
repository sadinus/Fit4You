using System.ComponentModel.DataAnnotations;

namespace Fit4You.WebApp.Models.Auth
{
    public class SignUpModel
    {
        [EmailAddress(ErrorMessage = "This is not an email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter your password again")]
        [Compare("Password", ErrorMessage = "Password does not match")]
        public string RepeatPassword { get; set; }
    }
}
