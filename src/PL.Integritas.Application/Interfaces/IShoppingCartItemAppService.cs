using PL.Integritas.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PL.Integritas.Application.Interfaces
{
    public interface IShoppingCartItemAppService : IDisposable
    {
        ShoppingCartItemViewModel Add(ShoppingCartItemViewModel shoppingCartItemViewModel);

        ShoppingCartItemViewModel Update(ShoppingCartItemViewModel shoppingCartItemViewModel);

        void Remove(Int64 id);

        ShoppingCartItemViewModel GetById(Int64 id);

        IEnumerable<ShoppingCartItemViewModel> GetAll();

        IEnumerable<ShoppingCartItemViewModel> GetRange(int skip, int take);
    }
}
