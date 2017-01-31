using PL.Integritas.Domain.Entities;
using PL.Integritas.Domain.Interfaces.Repositories;
using PL.Integritas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PL.Integritas.Domain.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public Purchase Add(Purchase purchase)
        {
            _purchaseRepository.Add(purchase);

            return purchase;
        }

        public Purchase Update(Purchase purchase)
        {
            _purchaseRepository.Update(purchase);

            return purchase;
        }

        public void Remove(Int64 id)
        {
            _purchaseRepository.Remove(id);
        }

        public Purchase GetById(Int64 id)
        {
            return _purchaseRepository.GetById(id);
        }

        public IEnumerable<Purchase> GetAll()
        {
            return _purchaseRepository.GetAll();
        }

        public IEnumerable<Purchase> GetRange(int skip, int take)
        {
            return _purchaseRepository.GetRange(skip, take);
        }

        public IEnumerable<Purchase> Search(Expression<Func<Purchase, bool>> predicate)
        {
            return _purchaseRepository.Search(predicate);
        }       
        
        public void Dispose()
        {
            _purchaseRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
