using System.ComponentModel.DataAnnotations;

namespace Fit4You.WebApp.Models
{
    public class BMRCalculatorModel
    {
        [Required(ErrorMessage = "Please choose your gender")]
        public bool? IsMale { get; set; }

        [Range(30, int.MaxValue, ErrorMessage = "Minimal value is {1}")]
        public int Weight { get; set; }

        [Range(100, int.MaxValue, ErrorMessage = "Minimal value is {1}")]
        public int Height { get; set; }

        [Range(18, int.MaxValue, ErrorMessage = "Minimal value is {1}")]
        public int Age { get; set; }

        public double Result { get; set; }
    }

    public enum ActivityType
    {
        None = 1,
        Low = 2,
        Medium = 3,
        High = 4,
        VeryHigh = 5
    }
}
