using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PL.Integritas.Domain.Entities;

namespace PL.Integritas.Infra.Data.EntityConfig
{
    public class ShoppingCartConfiguration : DbEntityConfiguration<ShoppingCart>
    {
        public override void Configure(EntityTypeBuilder<ShoppingCart> entity)
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Number);

            entity.Property(p => p.DateRegistered);

            entity.Property(p => p.DateUpdated);

            entity.Property(p => p.Active)
                .IsRequired();
        }
    }
}
