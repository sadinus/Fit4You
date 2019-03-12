using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4You.WebApp.Models
{
    public class HomeRegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public int Gender { get; set; }
        public int ActivityType { get; set; }
    }
}
