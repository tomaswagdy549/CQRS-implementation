using Catalog.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace App.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext
    {
        protected virtual void InitalizeContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            InitalizeContext();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(builder);
        }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductType> productTypes { get; set; }
        public DbSet<Brand> brands { get; set; }
    }
}