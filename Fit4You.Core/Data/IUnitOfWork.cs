using System;
using System.Collections.Generic;
using System.Text;
using Fit4You.Core.Data.Repositories;
using Fit4You.Core.Domain;

namespace Fit4You.Core.Data
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<UserData> UserDataRepository { get; }
        void Commit();
    }
}
