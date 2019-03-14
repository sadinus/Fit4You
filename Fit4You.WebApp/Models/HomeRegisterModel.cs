using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4You.WebApp.Models
{
    public class HomeRegisterModel
    {
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter your password again")]
        [Compare("Password")]
        public string RepeatPassword { get; set; }
    }
}
