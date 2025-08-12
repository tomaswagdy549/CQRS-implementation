using Catalog.Core.Entities;
using System.Linq.Expressions;

namespace Catalog.Core.Interfaces.GenericRepositoryInterface
{
    public interface IGetWithProjection<T>
    {
        public PaginationGenericResult<IQueryable<Dto>> GetWithProjection<Dto>(Expression<Func<T, Dto>> mappingExpression, int pageNumber, int pageSize, bool asNoTracking = true);
    }
}
