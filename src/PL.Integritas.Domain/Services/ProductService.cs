using PL.Integritas.Domain.Entities;
using PL.Integritas.Domain.Interfaces.Repositories;
using PL.Integritas.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PL.Integritas.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Add(Product product)
        {
            _productRepository.Add(product);

            return product;
        }

        public Product Update(Product product)
        {
            _productRepository.Update(product);

            return product;
        }

        public void Remove(Int64 id)
        {
            _productRepository.Remove(id);
        }

        public Product GetById(Int64 id)
        {
            return _productRepository.GetById(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetRange(int skip, int take)
        {
            return _productRepository.GetRange(skip, take);
        }

        public IEnumerable<Product> Search(Expression<Func<Product, bool>> predicate)
        {
            return _productRepository.Search(predicate);
        }       
        
        public void Dispose()
        {
            _productRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
