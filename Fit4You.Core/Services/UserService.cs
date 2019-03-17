using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fit4You.Core.Data;
using Fit4You.Core.Domain;

namespace Fit4You.Core.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> AddUser(string email, string password)
        {
            var emailLower = email.ToLowerInvariant();

            var userExists = _unitOfWork.UserRepository.UserWithGivenEmailExists(emailLower);

            if (userExists)
            {
                return Task.FromResult(false);
            }
            var entity = new User(emailLower, BCrypt.Net.BCrypt.HashPassword(password));
            _unitOfWork.UserRepository.Add(entity);
            _unitOfWork.Commit();
            return Task.FromResult(true);
        }

        public Task<bool> ValidateCredentials(string email, string password, out User user)
        {
            user = null;
            var userWithGivenEmailExists = _unitOfWork.UserRepository.UserWithGivenEmailExists(email.ToLowerInvariant());

            if (userWithGivenEmailExists)
            {
                user = _unitOfWork.UserRepository.GetByEmail(email);
                var hash = user.PasswordHash;
                if (BCrypt.Net.BCrypt.Verify(password, hash))
                {
                    return Task.FromResult(true);
                }
            }
            return Task.FromResult(false);
        }
    }
}
