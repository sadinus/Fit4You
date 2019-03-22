using System;
using System.Collections.Generic;
using System.Text;
using Fit4You.Core.Data.Repositories;
using Fit4You.Core.Domain;

namespace Fit4You.Core.Data
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IUserDataRepository UserDataRepository { get; }
        void Commit();
    }
}
