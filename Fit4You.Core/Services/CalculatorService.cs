using System;
using System.Collections.Generic;
using System.Text;

namespace Fit4You.Core.Services
{
    public class CalculatorService : ICalculatorService
    {
        public double CalculateBMI(int weight, int height)
        {
            if (height == 0)
            {
                return 0;
            }

            var weightAbs = Math.Abs(weight);
            var heightAbs = Math.Abs(height);
            var bmi = Math.Round((double)weightAbs / (heightAbs * heightAbs), 1);
            return bmi;
        }

        // Napisać kolejne kalkulatory
    }
}
