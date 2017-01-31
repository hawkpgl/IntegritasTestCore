using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PL.Integritas.Domain.Entities;
using System.Reflection;
using PL.Integritas.Infra.Data.EntityConfig;
using Microsoft.Extensions.Configuration;

namespace PL.Integritas.Infra.Data.Context
{
    public class IntegritasContext : DbContext
    {
        public IntegritasContext(DbContextOptions<IntegritasContext> options)
        : base(options)
        { }

        //public DbSet<Product> Products { get; set; }
        //public DbSet<Purchase> Purchases { get; set; }
        //public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        //public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Mappings

            modelBuilder.Entity<Product>();            
            modelBuilder.Entity<Purchase>();
            modelBuilder.Entity<ShoppingCart>();
            modelBuilder.Entity<ShoppingCartItem>();
            modelBuilder.AddConfiguration(new ProductConfiguration());
            modelBuilder.AddConfiguration(new PurchaseConfiguration());
            modelBuilder.AddConfiguration(new ShoppingCartConfiguration());
            modelBuilder.AddConfiguration(new ShoppingCartItemConfiguration());

            #endregion
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateRegistered") != null &&
                                                                         entry.Entity.GetType().GetProperty("DateUpdated") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateRegistered").CurrentValue = DateTime.Now;
                    entry.Property("DateUpdated").IsModified = false;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateUpdated").CurrentValue = DateTime.Now;
                    entry.Property("DateRegistered").IsModified = false;
                }

            }

            return base.SaveChanges();
        }
    }
}
