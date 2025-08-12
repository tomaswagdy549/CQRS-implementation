using Catalog.Core.Entities;
using System.Linq.Expressions;

namespace Catalog.Core.Interfaces.GenericRepositoryInterface
{
    public interface IFilter<T>
    {
        public PaginationGenericResult<IQueryable<T>> Filter(Expression<Func<T, bool>> filterExpression, int pageNumber, int pageSize,bool asNoTracking = true);
    }
}
