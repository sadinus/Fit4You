using AutoMapper;
using Fit4You.Core.Data;
using Fit4You.Core.Data.Repositories;
using Fit4You.Core.Domain;
using Fit4You.Core.Services;
using Fit4You.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Fit4You.WebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ICalculatorService calculatorService;
        private User GetCurrentUser() => unitOfWork.UserRepository.GetById(Int32.Parse(User.FindFirst("id").Value));


        public AccountController(IUnitOfWork unitOfWork, IMapper mapper, ICalculatorService calculatorService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.calculatorService = calculatorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserInformation()
        {
            var entity = unitOfWork.UserDataRepository.GetByUserId(GetCurrentUser().Id);
            UserInformationDisplayModel model;
            if (entity != null)
            {
                model = mapper.Map<UserData, UserInformationDisplayModel>(entity);
                var bmi = calculatorService.CalculateBMI(entity.Weight, entity.Height);
                model.BMI = bmi.ToString();
                model.BMIMeaning = calculatorService.GetMeaningOfBMI(bmi);
                model.BMR = calculatorService.CalculateBMR(entity.Weight, entity.Height, entity.Age, entity.isMale).ToString();

                return View(model);
            }

            model = new UserInformationDisplayModel("Unknown");
            return View(model);
        }

        public IActionResult UserInformationEdit()
        {
            var entity = unitOfWork.UserDataRepository.GetByUserId(GetCurrentUser().Id);

            if (entity != null)
            {
                var invalidModel = mapper.Map<UserData, UserInformationModel>(entity);
                return View(invalidModel);
            }

            var model = new UserInformationModel();
            model.IsSubscribed = true;
            return View(model);
        }

        [HttpPost]
        public IActionResult UserInformationEdit(UserInformationModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = unitOfWork.UserDataRepository.GetByUserId(GetCurrentUser().Id);

                if (entity != null)
                {
                    mapper.Map<UserInformationModel, UserData>(model, entity);
                    unitOfWork.UserDataRepository.Update(entity);
                }
                else
                {
                    entity = new UserData();
                    mapper.Map<UserInformationModel, UserData>(model, entity);
                    entity.UserID = GetCurrentUser().Id;
                    unitOfWork.UserDataRepository.Add(entity);
                }

                unitOfWork.Commit();

                return RedirectToAction(nameof(UserInformation));
            }
            return View(model);
        }
    }
}