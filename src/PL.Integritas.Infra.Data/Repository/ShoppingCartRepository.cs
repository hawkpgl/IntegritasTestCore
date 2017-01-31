using PL.Integritas.Domain.Entities;
using PL.Integritas.Domain.Interfaces.Repositories;
using PL.Integritas.Infra.Data.Context;

namespace PL.Integritas.Infra.Data.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository      
    {
        public ShoppingCartRepository(IntegritasContext integritasContext)
              : base(integritasContext)
        {

        }
    }
}
