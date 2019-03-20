using System.Diagnostics;
using AutoMapper;
using Fit4You.Core.Data;
using Fit4You.Core.Services;
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
        private readonly ICalculatorService _calculatorService;

        public HomeController(IMapper mapper, IUnitOfWork unitOfWork, ICalculatorService calculatorService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _calculatorService = calculatorService;
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
                model.Result = _calculatorService.CalculateBMI(model.Weight, model.Height);
                model.BMIMeaning = _calculatorService.GetMeaningOfBMI(model.Result);
            }
            return PartialView("_BMICalculatorPartial", model);
        }

        [HttpPost]
        public IActionResult CalculateBMR(BMRCalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                model.Result = _calculatorService.CalculateBMR(model.Weight, model.Height, model.Age, (bool)model.IsMale);
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
