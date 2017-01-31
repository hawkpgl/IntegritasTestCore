using PL.Integritas.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PL.Integritas.Application.Interfaces
{
    public interface IShoppingCartAppService : IDisposable
    {
        ShoppingCartViewModel Add(ShoppingCartViewModel shoppingCartViewModel);

        ShoppingCartViewModel Update(ShoppingCartViewModel shoppingCartViewModel);

        void Remove(Int64 id);

        ShoppingCartViewModel GetById(Int64 id);

        IEnumerable<ShoppingCartViewModel> GetAll();

        IEnumerable<ShoppingCartViewModel> GetRange(int skip, int take);

        ShoppingCartItemViewModel AddItemToCart(int cartNumber, int productId);

        IEnumerable<ShoppingCartItemViewModel> GetItemsByCartNumber(int cartNumber);
    }
}
