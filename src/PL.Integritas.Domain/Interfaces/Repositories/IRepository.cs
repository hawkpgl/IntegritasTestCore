using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PL.Integritas.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(Int64 id);

        TEntity GetById(Int64 id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetRange(int skip, int take);

        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);

        int SaveChanges();
    }
}
