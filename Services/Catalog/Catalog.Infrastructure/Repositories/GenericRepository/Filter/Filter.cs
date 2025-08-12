using App.Infrastructure;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces.GenericRepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Catalog.Infrastructure.Repositories.GenericRepository.Filter
{
    public class Filter<T> : IFilter<T> where T : class
    {
        readonly DbSet<T> _dbSet;
        public Filter(ApplicationDbContext ApplicationDbContext)
        {
            _dbSet = ApplicationDbContext.Set<T>();
        }

        PaginationGenericResult<IQueryable<T>> IFilter<T>.Filter(Expression<Func<T, bool>> filterExpression, int pageNumber, int pageSize,bool asNoTracking = true)
        {
            var query = asNoTracking ? _dbSet.AsNoTracking() : _dbSet;
            var result = query.Where(filterExpression).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            var count = query.Count(filterExpression);
            var paginationResult = new PaginationGenericResult<IQueryable<T>>()
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
