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

        public bool UserWithGivenEmailExists(string email)
        {
            return _dbContext.User.Any(x => x.Email == email);
        }

        public bool IsEmailAleadyTaken(string email, string username)
        {
            return _dbContext.User.Any(x => x.Email == email);
        }

        public User GetByEmail(string email)
        {
            return _dbContext.User.FirstOrDefault(x => x.Email == email);
        }
    }
}
