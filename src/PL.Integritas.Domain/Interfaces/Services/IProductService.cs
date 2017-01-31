using PL.Integritas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PL.Integritas.Domain.Interfaces.Services
{
    public interface IProductService : IDisposable
    {
        Product Add(Product product);

        Product Update(Product product);

        void Remove(Int64 id);

        Product GetById(Int64 id);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetRange(int skip, int take);

        IEnumerable<Product> Search(Expression<Func<Product, bool>> predicate);
    }
}
