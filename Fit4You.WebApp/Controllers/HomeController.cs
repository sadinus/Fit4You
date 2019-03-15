using System.Diagnostics;
using AutoMapper;
using Fit4You.Core.Data;
using Fit4You.Core.Domain;
using Fit4You.WebApp.Models;
using Fit4You.WebApp.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace Fit4You.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new User(model.Email, model.Password);
                var userExists = _unitOfWork.UserRepository.UserExists(entity);
                if (!userExists)
                {
                    _unitOfWork.UserRepository.Create(entity);
                    _unitOfWork.Commit();
                    return RedirectToAction(nameof(Login));
                }
                ModelState.AddModelError("Email", "This email is already taken. Try another one");
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new User(model.Email, model.Password);
                var correctCredentials = _unitOfWork.UserRepository.CorrectCredentials(entity);
                if (correctCredentials)
                {
                    // login
                    // open session
                    return RedirectToAction(nameof(Login));
                }
                _unitOfWork.UserRepository.UserExists(entity);
            }
            return View();
        }

        public IActionResult BMICalculator()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
