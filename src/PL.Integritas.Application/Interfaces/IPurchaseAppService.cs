using PL.Integritas.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PL.Integritas.Application.Interfaces
{
    public interface IPurchaseAppService : IDisposable
    {
        PurchaseViewModel Add(PurchaseViewModel purchaseViewModel);

        PurchaseViewModel Update(PurchaseViewModel purchaseViewModel);

        void Remove(Int64 id);

        PurchaseViewModel GetById(Int64 id);

        IEnumerable<PurchaseViewModel> GetAll();

        IEnumerable<PurchaseViewModel> GetRange(int skip, int take);
    }
}
