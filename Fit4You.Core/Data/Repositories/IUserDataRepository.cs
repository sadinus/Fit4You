using System;
using System.Collections.Generic;
using System.Text;
using Fit4You.Core.Domain;

namespace Fit4You.Core.Data.Repositories
{
    public interface IUserDataRepository : IGenericRepository<UserData>
    {
        UserData GetByUserId(int id);
    }
}
