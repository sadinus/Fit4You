using System;
using System.Collections.Generic;
using System.Text;
using Fit4You.Core.Data.Repositories;
using Fit4You.Core.Domain;

namespace Fit4You.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Fit4YouDbContext _context;
        private IGenericRepository<User> _userRepository;
        private IGenericRepository<UserData> _userDataRepository;
        public UnitOfWork(Fit4YouDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<User> UserRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new GenericRepository<User>(_context);
            }
        }

        public IGenericRepository<UserData> UserDataRepository
        {
            get
            {
                return _userDataRepository = _userDataRepository ?? new GenericRepository<UserData>(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
