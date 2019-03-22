using System.Diagnostics;
using AutoMapper;
using Fit4You.Core.Data;
using Fit4You.Core.Services;
using Fit4You.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fit4You.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICalculatorService calculatorService;

        public HomeController(IMapper mapper, IUnitOfWork unitOfWork, ICalculatorService calculatorService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.calculatorService = calculatorService;
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
                model.Result = calculatorService.CalculateBMI(model.Weight, model.Height);
                model.BMIMeaning = calculatorService.GetMeaningOfBMI(model.Result);
            }
            return PartialView("_BMICalculatorPartial", model);
        }

        [HttpPost]
        public IActionResult CalculateBMR(BMRCalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                model.Result = calculatorService.CalculateBMR(model.Weight, model.Height, model.Age, (bool)model.IsMale);
            }
            return PartialView("_BMRCalculatorPartial", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
