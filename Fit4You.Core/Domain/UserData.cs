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
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public Gender Gender { get; set; }
    }
}
