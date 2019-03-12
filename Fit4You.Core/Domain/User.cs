using System;
using System.Collections.Generic;
using System.Text;

namespace Fit4You.Core.Domain
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserData UserInfo { get; set; }
    }
}
