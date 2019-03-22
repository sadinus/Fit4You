using System;
using AutoMapper;
using Fit4You.Core.Data;
using Fit4You.Core.Domain;
using Fit4You.Core.Services;
using Fit4You.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fit4You.WebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ICalculatorService calculatorService;

        public AccountController(IUnitOfWork unitOfWork, IMapper mapper, ICalculatorService calculatorService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.calculatorService = calculatorService;
        }

        public IActionResult Index()
        {
            var userId = Int32.Parse(User.FindFirst("id").Value);
            var entity = unitOfWork.UserDataRepository.GetByUserId(userId);
            UserInformationDisplayModel model;
            if (entity != null)
            {
                model = mapper.Map<UserData, UserInformationDisplayModel>(entity);
                model.BMI = calculatorService.CalculateBMI(entity.Weight, entity.Height).ToString();
                model.BMR = calculatorService.CalculateBMR(entity.Weight, entity.Height, entity.Age, entity.isMale).ToString();

                return View(model);
            }

            model = new UserInformationDisplayModel("Unknown");
            return View(model);
        }

        public IActionResult UserInformation()
        {
            var userId = Int32.Parse(User.FindFirst("id").Value);
            var entity = unitOfWork.UserDataRepository.GetByUserId(userId);

            if (entity != null)
            {
                var model = mapper.Map<UserData, UserInformationModel>(entity);
                return View(model);
            }

            return View();
        }

        [HttpPost]
        public IActionResult UserInformation(UserInformationModel model)
        {
            if (ModelState.IsValid)
            {
                //unitOfWork.UserDataRepository.Add();
            }
            return View(model);
        }
    }
}