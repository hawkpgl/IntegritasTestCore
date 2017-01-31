using PL.Integritas.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PL.Integritas.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        ProductViewModel Add(ProductViewModel productViewModel);

        ProductViewModel Update(ProductViewModel productViewModel);

        void Remove(Int64 id);

        ProductViewModel GetById(Int64 id);

        IEnumerable<ProductViewModel> GetAll();

        IEnumerable<ProductViewModel> GetRange(int skip, int take);
    }
}
