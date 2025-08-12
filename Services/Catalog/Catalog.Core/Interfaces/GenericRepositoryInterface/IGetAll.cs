using Catalog.Core.Entities;

namespace Catalog.Core.Interfaces.GenericRepositoryInterface
{
    public interface IGetAll<T>
    {
        public PaginationGenericResult<IQueryable<T>> GetAll(int pageNumber, int pageSize, bool asNoTracking = true);
    }
}
