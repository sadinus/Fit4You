using System;
using System.Collections.Generic;
using System.Text;

namespace Fit4You.Core.Domain
{
    public class User
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public UserData UserInfo { get; set; }
    }
}
