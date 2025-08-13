using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Configurations.ProductType
{
    class ProductTypeConfiguration : IEntityTypeConfiguration<Core.Entities.ProductType>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.ProductType> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(ValuesLimiter.NameMaxLength);
        }
    }
}
