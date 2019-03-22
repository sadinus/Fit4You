using System.ComponentModel.DataAnnotations;

namespace Fit4You.WebApp.Models
{
    public class BMICalculatorModel
    {
        [Range(30, int.MaxValue, ErrorMessage = "Minimal value is {1}")]
        public int Weight { get; set; }

        [Range(100, int.MaxValue, ErrorMessage = "Minimal value is {1}")]
        public int Height { get; set; }

        public double Result { get; set; }
        public string BMIMeaning { get; set; }
    }
}
