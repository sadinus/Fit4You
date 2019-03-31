using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Fit4You.Core.Domain;

namespace Fit4You.Core.Services.Security
{
    public interface IAuthService
    {
        Task<bool> ValidateCredentials(string email, string password, out User user);
        Task<(bool result, int userId)> AddUser(string email, string password);
    }
}
