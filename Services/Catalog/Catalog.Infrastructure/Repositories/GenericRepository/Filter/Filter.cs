using Catalog.Core.Interfaces.GenericRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories.GenericRepository.Filter
{
    public class Filter<T> : IFilter<T>
    {
        Task<IQueryable<T>> IFilter<T>.Filter(Expression<Func<T, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }
    }
}
