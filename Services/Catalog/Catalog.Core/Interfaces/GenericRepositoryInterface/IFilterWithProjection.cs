using Catalog.Core.Entities;
using System.Linq.Expressions;

namespace Catalog.Core.Interfaces.GenericRepositoryInterface
{
    public interface IFilterWithProjection<T> 
    {
        public PaginationGenericResult<IQueryable<TDto>> FilterWithProjection<TDto>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, TDto>> mappingExpression, int pageNumber, int pageSize, bool asNoTracking = true);
    }
}
