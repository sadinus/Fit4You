using System;
using System.Collections.Generic;
using System.Text;

namespace Fit4You.Core.Domain
{
    public class User : IEntity
    {
        public User()
        {

        }

        public User(string email, string passwordHash)
        {
            Email = email;
            PasswordHash = passwordHash;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsSubscribed { get; set; }
        public UserData UserInfo { get; set; }
    }
}
