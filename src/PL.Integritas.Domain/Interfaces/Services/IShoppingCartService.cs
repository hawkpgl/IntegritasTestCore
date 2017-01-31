using PL.Integritas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PL.Integritas.Domain.Interfaces.Services
{
    public interface IShoppingCartService : IDisposable
    {
        ShoppingCart Add(ShoppingCart shoppingCart);

        ShoppingCart Update(ShoppingCart shoppingCart);

        void Remove(Int64 id);

        ShoppingCart GetById(Int64 id);

        IEnumerable<ShoppingCart> GetAll();

        IEnumerable<ShoppingCart> GetRange(int skip, int take);

        IEnumerable<ShoppingCart> Search(Expression<Func<ShoppingCart, bool>> predicate);
    }
}
