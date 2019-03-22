using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4You.WebApp.Models
{
    public class CalculatorsModel
    {
        public CalculatorsModel()
        {
            BMICalculator = new BMICalculatorModel();
            BMRCalculator = new BMRCalculatorModel();
        }
        public BMICalculatorModel BMICalculator { get; set; }
        public BMRCalculatorModel BMRCalculator { get; set; }
    }
}
