using App.Infrastructure;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces.GenericRepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Catalog.Infrastructure.Repositories.GenericRepository.FilterWithProjection
{
    public class FilterWithProjection<T> : IFilterWithProjection<T> where T : class
    {
        readonly DbSet<T> _dbSet;
        public FilterWithProjection(ApplicationDbContext ApplicationDbContext)
        {
            _dbSet = ApplicationDbContext.Set<T>();
        }
        PaginationGenericResult<IQueryable<Dto>> IFilterWithProjection<T>.FilterWithProjection<Dto>(Expression<Func<T, bool>> filterExpression, Expression<Func<T, Dto>> mappingExpression, int pageNumber, int pageSize,bool asNoTracking = true)  
        {
            var query = asNoTracking ? _dbSet.AsNoTracking() : _dbSet;
            var result = query.Where(filterExpression).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(mappingExpression);
            var count = query.Count(filterExpression);
            var paginationResult = new PaginationGenericResult<IQueryable<Dto>>()
            {
                Data = result,
                TotalCount = count,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return paginationResult;
        }
    }
}
