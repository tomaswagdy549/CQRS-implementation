using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Configurations.Brand
{
    public class BrandConfiguration : IEntityTypeConfiguration<Core.Entities.Brand>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Brand> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(ValuesLimiter.NamesMaxLength);
        }
    }
}
