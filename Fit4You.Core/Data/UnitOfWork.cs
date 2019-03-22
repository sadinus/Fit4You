using System;
using System.Collections.Generic;
using System.Text;
using Fit4You.Core.Data.Repositories;
using Fit4You.Core.Domain;

namespace Fit4You.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Fit4YouDbContext context;
        private IUserRepository userRepository;
        private IUserDataRepository userDataRepository;
        public UnitOfWork(Fit4YouDbContext context)
        {
            this.context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                return userRepository = userRepository ?? new UserRepository(context);
            }
        }

        public IUserDataRepository UserDataRepository
        {
            get
            {
                return userDataRepository = userDataRepository ?? new UserDataRepository(context);
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
