using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4You.WebApp.Models
{
    public class UserInformationModel
    {
        [Required(ErrorMessage = "Please choose your gender")]
        public bool? IsMale { get; set; }

        [Range(18, int.MaxValue, ErrorMessage = "Minimal value is {1}")]
        public int Age { get; set; }

        [Range(30, int.MaxValue, ErrorMessage = "Minimal value is {1}")]
        public decimal Weight { get; set; }

        [Range(100, int.MaxValue, ErrorMessage = "Minimal value is {1}")]
        public decimal Height { get; set; }

        public bool IsSubscribed { get; set; }
    }
}
