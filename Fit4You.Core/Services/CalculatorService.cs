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
            var heightInMeters = (double)heightAbs / 100;
            var bmi = Math.Round((double)weightAbs / (heightInMeters * heightInMeters), 1);
            return bmi;
        }

        public double CalculateBMR(int weight, int height, int age, bool isMale)
        {
            //Mifflin - St Jeor Equation

            int x = isMale ? 5 : -161;

            double result = (10 * weight) + (6.25 * height) - (5 * age) + x;

            return result;
        }

        public string GetMeaningOfBMI(double bmi)
        {
            var meaning = "";
            if (bmi < 18.5)
            {
                meaning = "underweight";
            }
            else if (bmi < 25)
            {
                meaning = "correct weight";
            }
            else if (bmi < 30)
            {
                meaning = "overweight";
            }
            else if (bmi < 35)
            {
                meaning = "obese";
            }
            else
            {
                meaning = "extremly obese";
            }
            return meaning;
        }
    }
}
