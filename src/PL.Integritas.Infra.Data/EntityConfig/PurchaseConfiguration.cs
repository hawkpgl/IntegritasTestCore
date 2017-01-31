using PL.Integritas.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PL.Integritas.Infra.Data.EntityConfig
{
    public class PurchaseConfiguration : DbEntityConfiguration<Purchase>
    {
        public override void Configure(EntityTypeBuilder<Purchase> entity)
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.CardHolderName)
                .HasMaxLength(50);

            entity.Property(p => p.CardNumber)
                .IsRequired()
                .HasMaxLength(16);

            entity.Property(p => p.CardExpiryMonth);

            entity.Property(p => p.CardExpiryYear);

            entity.Property(p => p.CVV)
                 .HasMaxLength(3);

            entity.Property(p => p.Adress)
                 .IsRequired()
                 .HasMaxLength(255);

            entity.Property(p => p.Country)
                 .HasMaxLength(50);

            entity.Property(p => p.State)
                 .HasMaxLength(100);

            entity.Property(p => p.City)
                 .HasMaxLength(100);

            entity.Property(p => p.ZipPostalCode)
                 .IsRequired()
                 .HasMaxLength(15);

            entity.Property(p => p.DateRegistered);

            entity.Property(p => p.DateUpdated);

            entity.Property(p => p.Active)
                  .IsRequired();
        }
    }
}
