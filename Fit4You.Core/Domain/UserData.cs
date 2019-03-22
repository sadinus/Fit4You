using System;
using System.Collections.Generic;
using System.Text;

namespace Fit4You.Core.Domain
{
    public class UserData : IEntity
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public bool isMale { get; set; }
    }
}
