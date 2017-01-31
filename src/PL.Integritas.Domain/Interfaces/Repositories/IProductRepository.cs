using PL.Integritas.Domain.Entities;
using System.Collections.Generic;

namespace PL.Integritas.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetByName(string name);
    }
}
