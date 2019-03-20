using System.Diagnostics;
using AutoMapper;
using Fit4You.Core.Data;
using Fit4You.Core.Domain;
using Fit4You.WebApp.Models;
using Fit4You.WebApp.Models.Home;
using Fit4You.WebApp.Models.Shared;
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

        public IActionResult Calculators()
        {
            var model = new CalculatorsModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult CalculateBMI(BMICalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                model.Result = 1;
            }
            return PartialView("_BMICalculatorPartial", model);
        }

        [HttpPost]
        public IActionResult CalculateBMR(BMRCalculatorModel model)
        {
            return PartialView("_BMRCalculatorPartial", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
