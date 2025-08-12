using App.Infrastructure;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces.GenericRepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories.GenericRepository.IGetWithProjection
{
    public class GetWithProjection<T> : IGetWithProjection<T> where T : class
    {
        readonly DbSet<T> _dbSet;
        public GetWithProjection(ApplicationDbContext ApplicationDbContext)
        {
            _dbSet = ApplicationDbContext.Set<T>();
        }
        PaginationGenericResult<IQueryable<Dto>> IGetWithProjection<T>.GetWithProjection<Dto>(Expression<Func<T,Dto>> mappingExpression,int pageNumber,int pageSize,bool asNoTracking = true)
        {
            var query = asNoTracking ? _dbSet.AsNoTracking() : _dbSet;
            var result = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(mappingExpression);
            var count = query.Count();
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
