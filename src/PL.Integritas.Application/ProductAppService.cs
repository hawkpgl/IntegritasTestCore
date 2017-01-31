using PL.Integritas.Application.Interfaces;
using PL.Integritas.Application.ViewModels;
using PL.Integritas.Domain.Entities;
using PL.Integritas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PL.Integritas.Application
{
    public class ProductAppService : AppService, IProductAppService
    {
        private readonly IProductService _productService;

        public ProductAppService(IProductService productService)
        {
            _productService = productService;
        }

        public ProductViewModel Add(ProductViewModel productViewModel)
        {
            var product = new Product
            {
                Id = productViewModel.Id,
                Active = productViewModel.Active,
                Name = productViewModel.Name
            };

            BeginTransaction();

            _productService.Add(product);

            Commit();

            return productViewModel;
        }

        public ProductViewModel Update(ProductViewModel productViewModel)
        {
            var product = new Product
            {
                Id = productViewModel.Id,
                Active = productViewModel.Active,
                Name = productViewModel.Name
            };

            BeginTransaction();

            _productService.Update(product);

            Commit();

            return productViewModel;
        }

        public void Remove(Int64 id)
        {
            BeginTransaction();

            var product = _productService.GetById(id);

            product.Active = false;

            _productService.Update(product);

            Commit();
        }

        public ProductViewModel GetById(Int64 id)
        {
            return new ProductViewModel(_productService.GetById(id));
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            IEnumerable<Product> products = _productService.Search(x => x.Active == true);

            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            if (products != null)
            {
                foreach (var product in products)
                {
                    productViewModels.Add(new ProductViewModel(product));
                }
            }

            return productViewModels;
        }

        public IEnumerable<ProductViewModel> GetRange(int skip, int take)
        {
            IEnumerable<Product> products = _productService.GetRange(skip, take);

            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            if (products != null)
            {
                foreach (var product in products)
                {
                    productViewModels.Add(new ProductViewModel(product));
                }
            }

            return productViewModels;
        }
        
        public void Dispose()
        {
            _productService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
