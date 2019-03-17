using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fit4You.Core.Domain;

namespace Fit4You.Core.Data.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        List<TEntity> FindAll();

        TEntity GetById(int id);

        void Add(TEntity entity);

        void Update(int id, TEntity entity);

        void Delete(int id);
    }
}
