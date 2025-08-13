using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Configurations.Product
{
    class ProductConfiguration : IEntityTypeConfiguration<Core.Entities.Product>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Product> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(ValuesLimiter.NameMaxLength);
            builder.Property(p => p.Description).HasMaxLength(ValuesLimiter.DescriptionMaxLength);
            builder.Property(p => p.ImageFile).HasMaxLength(ValuesLimiter.ImageLinkMaxLength);
        }
    }
}
