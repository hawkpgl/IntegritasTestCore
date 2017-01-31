using PL.Integritas.Application.Interfaces;
using PL.Integritas.Application.ViewModels;
using PL.Integritas.Domain.Entities;
using PL.Integritas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PL.Integritas.Application
{
    public class ShoppingCartAppService : AppService, IShoppingCartAppService
    {
        private readonly IProductService _productService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IShoppingCartItemService _shoppingCartItemService;

        public ShoppingCartAppService(IShoppingCartService shoppingCartService,
                                      IShoppingCartItemService shoppingCartItemService,
                                      IProductService productService)
        {
            _shoppingCartService = shoppingCartService;
            _shoppingCartItemService = shoppingCartItemService;
            _productService = productService;
        }

        public ShoppingCartViewModel Add(ShoppingCartViewModel shoppingCartViewModel)
        {
            var shoppingCart = new ShoppingCart
            {
                Id = shoppingCartViewModel.Id,
                Active = shoppingCartViewModel.Active,
                Number = shoppingCartViewModel.Number
            };

            foreach (var item in shoppingCartViewModel.ItemsViewModel)
            {
                ShoppingCartItem shoppingCartItem = new ShoppingCartItem { Id = item.Id, ProductId = item.ProductId, ShoppingCartId = item.ShoppingCartId };
                shoppingCart.AddItem(shoppingCartItem);
            }

            BeginTransaction();

            _shoppingCartService.Add(shoppingCart);

            Commit();

            return shoppingCartViewModel;
        }

        public ShoppingCartItemViewModel AddItemToCart(int cartNumber, int productId)
        {
            ShoppingCart shoppingCart = _shoppingCartService.Search(x => x.Number == cartNumber).FirstOrDefault();
            
            if (shoppingCart == null)
            {
                Add(new ShoppingCartViewModel { Number = cartNumber });

                shoppingCart = _shoppingCartService.Search(x => x.Number == cartNumber).FirstOrDefault();
            }

            ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel(shoppingCart);

            BeginTransaction();

            ShoppingCartItem item = new ShoppingCartItem();
            item.ProductId = productId;
            item.ShoppingCartId = shoppingCartViewModel.Id;

            ShoppingCartItemViewModel shoppingCartItemViewModel = new ShoppingCartItemViewModel(_shoppingCartItemService.Add(item));
           
            Commit();

            return shoppingCartItemViewModel;
        }

        public ShoppingCartViewModel Update(ShoppingCartViewModel shoppingCartViewModel)
        {
            var shoppingCart = new ShoppingCart
            {
                Id = shoppingCartViewModel.Id,
                Active = shoppingCartViewModel.Active,
                Number = shoppingCartViewModel.Number
            };

            foreach (var item in shoppingCartViewModel.ItemsViewModel)
            {
                ShoppingCartItem shoppingCartItem = new ShoppingCartItem { Id = item.Id, ProductId = item.ProductId, ShoppingCartId = item.ShoppingCartId };
                shoppingCart.AddItem(shoppingCartItem);
            }

            BeginTransaction();

            _shoppingCartService.Update(shoppingCart);

            Commit();

            return shoppingCartViewModel;
        }

        public void Remove(Int64 id)
        {
            BeginTransaction();

            var shoppingCart = _shoppingCartService.GetById(id);

            shoppingCart.Active = false;

            _shoppingCartService.Update(shoppingCart);

            Commit();
        }

        public ShoppingCartViewModel GetById(Int64 id)
        {
            return new ShoppingCartViewModel(_shoppingCartService.GetById(id));
        }

        public IEnumerable<ShoppingCartViewModel> GetAll()
        {
            IEnumerable<ShoppingCart> shoppingCarts = _shoppingCartService.Search(x => x.Active == true);

            List<ShoppingCartViewModel> shoppingCartViewModels = new List<ShoppingCartViewModel>();

            if (shoppingCarts != null)
            {
                foreach (var shoppingCart in shoppingCarts)
                {
                    shoppingCartViewModels.Add(new ShoppingCartViewModel(shoppingCart));
                }
            }

            return shoppingCartViewModels;
        }

        public IEnumerable<ShoppingCartItemViewModel> GetItemsByCartNumber(int cartNumber)
        {
            ShoppingCart shoppingCart = _shoppingCartService.Search(x => x.Number == cartNumber).FirstOrDefault();

            ShoppingCartViewModel shoppingCartViewModel =  new ShoppingCartViewModel();

            if (shoppingCart != null)
            {
                shoppingCartViewModel = new ShoppingCartViewModel(shoppingCart);
            }

            if (shoppingCartViewModel == null)
            {
                Add(new ShoppingCartViewModel { Number = cartNumber });

                shoppingCart = _shoppingCartService.Search(x => x.Number == cartNumber).FirstOrDefault();

                shoppingCartViewModel = new ShoppingCartViewModel(shoppingCart);
            }

            IEnumerable<ShoppingCartItem> items = _shoppingCartItemService.Search(x => x.ShoppingCart.Number == cartNumber);

            List<ShoppingCartItemViewModel> itemsViewModels = new List<ShoppingCartItemViewModel>();

            if (items != null)
            {
                foreach (var item in items)
                {
                    itemsViewModels.Add(new ShoppingCartItemViewModel(item));
                }
            }

            foreach (var item in itemsViewModels)
            {
                item.Name = _productService.GetById(item.ProductId).Name;
            }

            return itemsViewModels;
        }

        public IEnumerable<ShoppingCartViewModel> GetRange(int skip, int take)
        {
            IEnumerable<ShoppingCart> shoppingCarts = _shoppingCartService.GetRange(skip, take);

            List<ShoppingCartViewModel> shoppingCartViewModels = new List<ShoppingCartViewModel>();

            if (shoppingCarts != null)
            {
                foreach (var shoppingCart in shoppingCarts)
                {
                    shoppingCartViewModels.Add(new ShoppingCartViewModel(shoppingCart));
                }
            }

            return shoppingCartViewModels;
        }
        
        public void Dispose()
        {
            _shoppingCartService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
