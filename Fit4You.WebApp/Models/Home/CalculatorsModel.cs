﻿using Fit4You.WebApp.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4You.WebApp.Models.Home
{
    public class CalculatorsModel
    {
        public BMICalculatorModel BMICalculator { get; set; }
        public BMRCalculatorModel BMRCalculator { get; set; }
    }
}
