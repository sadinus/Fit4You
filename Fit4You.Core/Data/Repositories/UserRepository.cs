using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fit4You.Core.Domain;

namespace Fit4You.Core.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly Fit4YouDbContext _dbContext;
        public UserRepository(Fit4YouDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public bool UserExists(User user)
        {
            return _dbContext.User.Any(x => x.Email == user.Email);
        }

        public bool CorrectCredentials(User user)
        {
            return _dbContext.User.Any(x => x.Email == user.Email && x.Password == user.Password);
        }
    }
}
