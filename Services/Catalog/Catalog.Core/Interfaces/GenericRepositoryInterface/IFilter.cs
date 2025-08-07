using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Interfaces.GenericRepositoryInterface
{
    public interface IFilter<T>
    {
        public Task<IQueryable<T>> Filter(Expression<Func<T, bool>> filterExpression);
    }
}
