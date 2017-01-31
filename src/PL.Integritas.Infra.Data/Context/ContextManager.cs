using Microsoft.EntityFrameworkCore;
using PL.Integritas.Infra.Data.Interfaces;

namespace PL.Integritas.Infra.Data.Context
{
    public class ContextManager : IContextManager
    {
        private const string ContextKey = "ContextManager.Context";

        public IntegritasContext GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<IntegritasContext>();
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-SLOU7DL\LOCALDB;Database=IntegritasDB;Trusted_Connection=True;");
           
            return new IntegritasContext(optionsBuilder.Options);
        }
    }
}
