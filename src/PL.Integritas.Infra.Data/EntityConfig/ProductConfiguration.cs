using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PL.Integritas.Domain.Entities;

namespace PL.Integritas.Infra.Data.EntityConfig
{
    public class ProductConfiguration : DbEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(p => p.DateRegistered);

            entity.Property(p => p.DateUpdated);

            entity.Property(p => p.Active)
                .IsRequired();
        }
    }
}
