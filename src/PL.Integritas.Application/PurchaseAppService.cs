using PL.Integritas.Application.Interfaces;
using PL.Integritas.Application.ViewModels;
using PL.Integritas.Domain.Entities;
using PL.Integritas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PL.Integritas.Application
{
    public class PurchaseAppService : AppService, IPurchaseAppService
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IShoppingCartService _shoppingCartService;

        public PurchaseAppService(IPurchaseService purchaseService,
                                  IShoppingCartService shoppingCartService)
        {
            _purchaseService = purchaseService;
            _shoppingCartService = shoppingCartService;
        }

        public PurchaseViewModel Add(PurchaseViewModel purchaseViewModel)
        {
            ShoppingCart shoppingCart = _shoppingCartService.Search(x => x.Number == purchaseViewModel.CartNumber).FirstOrDefault();

            if (shoppingCart == null)
            {
                throw new Exception("Shopping Cart doesn't exists.");
            }

            var purchase = new Purchase
            {
                Id = purchaseViewModel.Id,
                Active = purchaseViewModel.Active,
                CardHolderName = purchaseViewModel.CardHolderName,
                CardNumber = purchaseViewModel.CardNumber,
                CardExpiryMonth = purchaseViewModel.CardExpiryMonth,
                CardExpiryYear = purchaseViewModel.CardExpiryYear,
                CVV = purchaseViewModel.CVV,
                Adress = purchaseViewModel.Adress,
                Country = purchaseViewModel.Country,
                State = purchaseViewModel.State,
                City = purchaseViewModel.City,
                ZipPostalCode = purchaseViewModel.ZipPostalCode,
                ShoppingCartId = shoppingCart.Id
            };
            
            BeginTransaction();

            _purchaseService.Add(purchase);

            Commit();

            return purchaseViewModel;
        }

        public PurchaseViewModel Update(PurchaseViewModel purchaseViewModel)
        {
            var purchase = new Purchase
            {
                Id = purchaseViewModel.Id,
                Active = purchaseViewModel.Active,
                CardHolderName = purchaseViewModel.CardHolderName,
                CardNumber = purchaseViewModel.CardNumber,
                CardExpiryMonth = purchaseViewModel.CardExpiryMonth,
                CardExpiryYear = purchaseViewModel.CardExpiryYear,
                CVV = purchaseViewModel.CVV,
                Adress = purchaseViewModel.Adress,
                Country = purchaseViewModel.Country,
                State = purchaseViewModel.State,
                City = purchaseViewModel.City,
                ZipPostalCode = purchaseViewModel.ZipPostalCode,
                ShoppingCartId = purchaseViewModel.Id
            };

            BeginTransaction();

            _purchaseService.Update(purchase);

            Commit();

            return purchaseViewModel;
        }

        public void Remove(Int64 id)
        {
            BeginTransaction();

            var purchase = _purchaseService.GetById(id);

            purchase.Active = false;

            _purchaseService.Update(purchase);

            Commit();
        }

        public PurchaseViewModel GetById(Int64 id)
        {
            return new PurchaseViewModel(_purchaseService.GetById(id));
        }

        public IEnumerable<PurchaseViewModel> GetAll()
        {
            IEnumerable<Purchase> purchases = _purchaseService.Search(x => x.Active == true);

            List<PurchaseViewModel> purchaseViewModels = new List<PurchaseViewModel>();

            if (purchases != null)
            {
                foreach (var purchase in purchases)
                {
                    purchaseViewModels.Add(new PurchaseViewModel(purchase));
                }
            }

            foreach (var purchaseViewModel in purchaseViewModels.ToList())
            {
                purchaseViewModel.CartNumber = _shoppingCartService.GetById(purchaseViewModel.ShoppingCartId).Number;
            }            

            return purchaseViewModels;
        }

        public IEnumerable<PurchaseViewModel> GetRange(int skip, int take)
        {
            IEnumerable<Purchase> purchases = _purchaseService.GetRange(skip, take);

            List<PurchaseViewModel> purchaseViewModels = new List<PurchaseViewModel>();

            if (purchases != null)
            {
                foreach (var purchase in purchases)
                {
                    purchaseViewModels.Add(new PurchaseViewModel(purchase));
                }
            }

            foreach (var purchaseViewModel in purchaseViewModels.ToList())
            {
                purchaseViewModel.CartNumber = _shoppingCartService.GetById(purchaseViewModel.ShoppingCartId).Number;
            }

            return purchaseViewModels;
        }
        
        public void Dispose()
        {
            _purchaseService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
