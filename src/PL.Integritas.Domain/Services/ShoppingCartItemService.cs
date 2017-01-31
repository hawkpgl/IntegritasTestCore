using PL.Integritas.Domain.Entities;
using PL.Integritas.Domain.Interfaces.Repositories;
using PL.Integritas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PL.Integritas.Domain.Services
{
    public class ShoppingCartItemService : IShoppingCartItemService
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

        public ShoppingCartItemService(IShoppingCartItemRepository shoppingCartItemRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }

        public ShoppingCartItem Add(ShoppingCartItem shoppingCartItem)
        {
            _shoppingCartItemRepository.Add(shoppingCartItem);

            return shoppingCartItem;
        }

        public ShoppingCartItem Update(ShoppingCartItem shoppingCartItem)
        {
            _shoppingCartItemRepository.Update(shoppingCartItem);

            return shoppingCartItem;
        }

        public void Remove(Int64 id)
        {
            _shoppingCartItemRepository.Remove(id);
        }

        public ShoppingCartItem GetById(Int64 id)
        {
            return _shoppingCartItemRepository.GetById(id);
        }

        public IEnumerable<ShoppingCartItem> GetAll()
        {
            return _shoppingCartItemRepository.GetAll();
        }

        public IEnumerable<ShoppingCartItem> GetRange(int skip, int take)
        {
            return _shoppingCartItemRepository.GetRange(skip, take);
        }

        public IEnumerable<ShoppingCartItem> Search(Expression<Func<ShoppingCartItem, bool>> predicate)
        {
            return _shoppingCartItemRepository.Search(predicate);
        }       
        
        public void Dispose()
        {
            _shoppingCartItemRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
