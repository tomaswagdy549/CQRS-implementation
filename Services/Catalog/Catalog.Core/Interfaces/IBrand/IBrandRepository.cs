using Catalog.Core.Entities;

namespace Catalog.Core.Repositories.IBrand;
public interface IBrandRepository
{
    Task<IEnumerable<Brand>> GetAllBrandAsync(CancellationToken cancellationToken = default);
}
