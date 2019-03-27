using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fit4You.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fit4You.Core.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly Fit4YouDbContext dbContext;
        public UserRepository(Fit4YouDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool UserWithGivenEmailExists(string email)
        {
            return dbContext.User.Any(x => x.Email == email);
        }

        public User GetByEmail(string email)
        {
            return dbContext.User.AsNoTracking().FirstOrDefault(x => x.Email == email);
        }

        public List<User> FindUsersWithSubscription()
        {
            return dbContext.User.AsNoTracking()
                                 .Include(x => x.UserInfo)
                                 .Where(x => x.UserInfo.IsSubscribed == true)
                                 .ToList();
        }
    }
}
