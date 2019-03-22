using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Fit4You.Core.Domain;
using Fit4You.Core.Services;
using Fit4You.WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Fit4You.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                User user;
                if (await userService.ValidateCredentials(model.Email, model.Password, out user))
                {
                    await LogInUser(user.Id, user.Email);
                    if (returnUrl != null)
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Account");
                }
                ModelState.AddModelError("Error", "Email or password is incorrect");
            }

            return View(model);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                var callback = await userService.AddUser(model.Email, model.Password);
                if (callback.result)
                {
                    await LogInUser(callback.userId, model.Email);
                    return RedirectToAction("Index", "Account");
                }
                ModelState.AddModelError("Error", "User with this email already exists");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task LogInUser(int userId, string email)
        {
            var claims = new List<Claim>
            {
                new Claim("id", userId.ToString()),
                new Claim("name", email)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", null);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);
        }
    }
}
