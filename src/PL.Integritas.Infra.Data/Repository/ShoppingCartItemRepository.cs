using PL.Integritas.Domain.Entities;
using PL.Integritas.Domain.Interfaces.Repositories;
using PL.Integritas.Infra.Data.Context;

namespace PL.Integritas.Infra.Data.Repository
{
    public class ShoppingCartItemRepository : Repository<ShoppingCartItem>, IShoppingCartItemRepository
    {
        public ShoppingCartItemRepository(IntegritasContext integritasContext)
              : base(integritasContext)
        {

        }
    }
}
