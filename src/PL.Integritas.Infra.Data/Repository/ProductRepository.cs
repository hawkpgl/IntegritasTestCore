using PL.Integritas.Domain.Entities;
using PL.Integritas.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace PL.Integritas.Infra.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public IEnumerable<Product> GetByName(string name)
        {
            return Search(x => name.Contains(x.Name));
        }
    }
}
