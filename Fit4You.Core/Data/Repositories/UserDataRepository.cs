using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fit4You.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fit4You.Core.Data.Repositories
{
    public class UserDataRepository : GenericRepository<UserData>, IUserDataRepository
    {
        private readonly Fit4YouDbContext dbContext;
        public UserDataRepository(Fit4YouDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public UserData GetByUserId(int id)
        {
            return dbContext.UserData.AsNoTracking().FirstOrDefault(x => x.UserID == id);
        }
    }
}
