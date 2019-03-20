using System.ComponentModel.DataAnnotations;

namespace Fit4You.WebApp.Models.Shared
{
    public class BMRCalculatorModel
    {
        [Required(ErrorMessage = "Please choose your gender")]
        public bool? IsMan { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }
        public ActivityType ActivityType { get; set; }
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
