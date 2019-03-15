﻿using System.ComponentModel.DataAnnotations;

namespace Fit4You.WebApp.Models.Home
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "This is not an email address")]
        [Required(ErrorMessage = "Enter your email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }
    }
}
