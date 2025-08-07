using App.Infrastructure;
using Catalog.Core.Repositories.IBrand;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories.Brand
{
    public class BrandRepository : IBrandRepository
    {
        DbSet<Core.Entities.Brand> _brands { get; set; }
        public BrandRepository(ApplicationDbContext applicationDbContext)
        {
            _brands = applicationDbContext.Set<Core.Entities.Brand>();
        }
        public async Task<IEnumerable<Core.Entities.Brand>> GetAllBrandAsync(CancellationToken cancellationToken = default)
        {
            var result = await _brands.ToListAsync(cancellationToken);
            return result;
        }
    }
}
