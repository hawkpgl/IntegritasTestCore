using PL.Integritas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PL.Integritas.Domain.Interfaces.Services
{
    public interface IPurchaseService : IDisposable
    {
        Purchase Add(Purchase purchase);

        Purchase Update(Purchase purchase);

        void Remove(Int64 id);

        Purchase GetById(Int64 id);

        IEnumerable<Purchase> GetAll();

        IEnumerable<Purchase> GetRange(int skip, int take);

        IEnumerable<Purchase> Search(Expression<Func<Purchase, bool>> predicate);
    }
}
