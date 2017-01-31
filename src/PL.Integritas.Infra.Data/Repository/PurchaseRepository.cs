using PL.Integritas.Domain.Entities;
using PL.Integritas.Domain.Interfaces.Repositories;
using PL.Integritas.Infra.Data.Context;

namespace PL.Integritas.Infra.Data.Repository
{
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(IntegritasContext integritasContext)
              : base(integritasContext)
        {

        }
    }
}
