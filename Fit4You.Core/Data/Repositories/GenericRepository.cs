using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fit4You.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fit4You.Core.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly Fit4YouDbContext _dbContext;

        public GenericRepository(Fit4YouDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TEntity> FindAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>()
                             .AsNoTracking()
                             .FirstOrDefault(e => e.Id == id);
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public void Update(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
        }
    }
}
