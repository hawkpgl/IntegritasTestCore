using PL.Integritas.Domain.Entities;
using PL.Integritas.Domain.Interfaces.Repositories;
using PL.Integritas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PL.Integritas.Domain.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public ShoppingCart Add(ShoppingCart shoppingCart)
        {
            _shoppingCartRepository.Add(shoppingCart);

            return shoppingCart;
        }

        public ShoppingCart Update(ShoppingCart shoppingCart)
        {
            _shoppingCartRepository.Update(shoppingCart);

            return shoppingCart;
        }

        public void Remove(Int64 id)
        {
            _shoppingCartRepository.Remove(id);
        }

        public ShoppingCart GetById(Int64 id)
        {
            return _shoppingCartRepository.GetById(id);
        }

        public IEnumerable<ShoppingCart> GetAll()
        {
            return _shoppingCartRepository.GetAll();
        }

        public IEnumerable<ShoppingCart> GetRange(int skip, int take)
        {
            return _shoppingCartRepository.GetRange(skip, take);
        }

        public IEnumerable<ShoppingCart> Search(Expression<Func<ShoppingCart, bool>> predicate)
        {
            return _shoppingCartRepository.Search(predicate);
        }       
        
        public void Dispose()
        {
            _shoppingCartRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
