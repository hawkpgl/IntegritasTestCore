using PL.Integritas.Application.Interfaces;
using PL.Integritas.Application.ViewModels;
using PL.Integritas.Domain.Entities;
using PL.Integritas.Domain.Interfaces.Services;
using PL.Integritas.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace PL.Integritas.Application
{
    public class ShoppingCartItemAppService : AppService, IShoppingCartItemAppService
    {
        private readonly IShoppingCartItemService _shoppingCartItemService;

        public ShoppingCartItemAppService(IShoppingCartItemService shoppingCartItemService, 
                                          IUnityOfWork uow)
            : base(uow)
        {
            _shoppingCartItemService = shoppingCartItemService;
        }

        public ShoppingCartItemViewModel Add(ShoppingCartItemViewModel shoppingCartItemViewModel)
        {
            var shoppingCartItem = new ShoppingCartItem
            {
                Id = shoppingCartItemViewModel.Id,
                Active = shoppingCartItemViewModel.Active,
                ProductId = shoppingCartItemViewModel.ProductId,
                ShoppingCartId = shoppingCartItemViewModel.ShoppingCartId
            };

            BeginTransaction();

            _shoppingCartItemService.Add(shoppingCartItem);

            Commit();

            return shoppingCartItemViewModel;
        }

        public ShoppingCartItemViewModel Update(ShoppingCartItemViewModel shoppingCartItemViewModel)
        {
            var shoppingCartItem = new ShoppingCartItem
            {
                Id = shoppingCartItemViewModel.Id,
                Active = shoppingCartItemViewModel.Active,
                ProductId = shoppingCartItemViewModel.ProductId,
                ShoppingCartId = shoppingCartItemViewModel.ShoppingCartId
            };

            BeginTransaction();

            _shoppingCartItemService.Update(shoppingCartItem);

            Commit();

            return shoppingCartItemViewModel;
        }

        public void Remove(Int64 id)
        {
            BeginTransaction();

            var shoppingCartItem = _shoppingCartItemService.GetById(id);

            shoppingCartItem.Active = false;

            _shoppingCartItemService.Update(shoppingCartItem);

            Commit();
        }

        public ShoppingCartItemViewModel GetById(Int64 id)
        {
            return new ShoppingCartItemViewModel(_shoppingCartItemService.GetById(id));
        }

        public IEnumerable<ShoppingCartItemViewModel> GetAll()
        {
            IEnumerable<ShoppingCartItem> shoppingCartItems = _shoppingCartItemService.Search(x => x.Active == true);

            List<ShoppingCartItemViewModel> shoppingCartItemViewModels = new List<ShoppingCartItemViewModel>();

            if (shoppingCartItems != null)
            {
                foreach (var shoppingCart in shoppingCartItems)
                {
                    shoppingCartItemViewModels.Add(new ShoppingCartItemViewModel(shoppingCart));
                }
            }

            return shoppingCartItemViewModels;
        }

        public IEnumerable<ShoppingCartItemViewModel> GetRange(int skip, int take)
        {
            IEnumerable<ShoppingCartItem> shoppingCartItems = _shoppingCartItemService.GetRange(skip, take);

            List<ShoppingCartItemViewModel> shoppingCartItemViewModels = new List<ShoppingCartItemViewModel>();

            if (shoppingCartItems != null)
            {
                foreach (var shoppingCart in shoppingCartItems)
                {
                    shoppingCartItemViewModels.Add(new ShoppingCartItemViewModel(shoppingCart));
                }
            }

            return shoppingCartItemViewModels;
        }
        
        public void Dispose()
        {
            _shoppingCartItemService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
