using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PL.Integritas.Infra.Data.EntityConfig
{
    public abstract class DbEntityConfiguration<TEntity> where TEntity : class
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> entity);
    }
}
