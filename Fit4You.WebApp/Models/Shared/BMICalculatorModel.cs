using System.ComponentModel.DataAnnotations;

namespace Fit4You.WebApp.Models.Shared
{
    public class BMICalculatorModel
    {
        [Required(ErrorMessage = "Please choose your gender")]
        public bool? IsMan { get; set; }
        [Range(30, int.MaxValue, ErrorMessage = "Minimal value is {1}")]
        public int Height { get; set; }
        [Range(100, int.MaxValue, ErrorMessage = "Minimal value is {1}")]
        public int Weight { get; set; }
        public double Result { get; set; }
    }
}
