using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4You.WebApp.Models.Shared
{
    public class BMICalculatorModel
    {
        public bool IsMan { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
