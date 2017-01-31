using PL.Integritas.Infra.Data.Context;

namespace PL.Integritas.Infra.Data.Interfaces
{
    public interface IContextManager
    {
        IntegritasContext GetContext();
    }
}
