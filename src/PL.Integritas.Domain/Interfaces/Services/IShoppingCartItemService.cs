using PL.Integritas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PL.Integritas.Domain.Interfaces.Services
{
    public interface IShoppingCartItemService : IDisposable
    {
        ShoppingCartItem Add(ShoppingCartItem shoppingCartItem);

        ShoppingCartItem Update(ShoppingCartItem shoppingCartItem);

        void Remove(Int64 id);

        ShoppingCartItem GetById(Int64 id);

        IEnumerable<ShoppingCartItem> GetAll();

        IEnumerable<ShoppingCartItem> GetRange(int skip, int take);

        IEnumerable<ShoppingCartItem> Search(Expression<Func<ShoppingCartItem, bool>> predicate);
    }
}
