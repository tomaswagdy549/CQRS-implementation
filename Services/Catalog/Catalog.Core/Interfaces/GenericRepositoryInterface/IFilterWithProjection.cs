using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Interfaces.GenericRepositoryInterface
{
    public interface IFilterWithProjection<T>
    {
        public IQueryable<Dto> FilterWithProjection<Dto>(Expression<Func<T, bool>> FilterExpression);
    }
}
