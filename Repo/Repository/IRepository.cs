using Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repository
{
    public interface IRepository<TKey, TEntity> where TEntity : IEntities<TKey>
    {
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();
        TKey Insert(TEntity entity);
        bool Delete(TKey id);
        bool Update(TEntity entity);
    }
}
