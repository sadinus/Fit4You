using System;
using System.Collections.Generic;
using System.Text;

namespace Fit4You.Core.Domain
{
    public class UserData
    {
        public int Age { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public Gender Gender { get; set; }
        public ActivityType ActivityType { get; set; }
    }
}
