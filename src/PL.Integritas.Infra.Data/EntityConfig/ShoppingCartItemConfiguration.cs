using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PL.Integritas.Domain.Entities;

namespace PL.Integritas.Infra.Data.EntityConfig
{
    public class ShoppingCartItemConfiguration : DbEntityConfiguration<ShoppingCartItem>
    {
        public override void Configure(EntityTypeBuilder<ShoppingCartItem> entity)
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.DateRegistered);

            entity.Property(p => p.DateUpdated);

            entity.Property(p => p.Active)
                .IsRequired();
        }
    }
}
