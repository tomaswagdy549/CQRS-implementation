using Catalog.Core.Interfaces.GenericRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories.GenericRepository.FilterWithProjection
{
    public class FilterWithProjection<T> : IFilterWithProjection<T>
    {
        IQueryable<Dto> IFilterWithProjection<T>.FilterWithProjection<Dto>(Expression<Func<T, bool>> FilterExpression)
        {
            throw new NotImplementedException();
        }
    }
}
