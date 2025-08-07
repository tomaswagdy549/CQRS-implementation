using Catalog.Core.Interfaces.GenericRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories.GenericRepository.IGetWithProjection
{
    public class GetWithProjection<T> : IGetWithProjection<T>
    {
        Task<IQueryable<Dto>> IGetWithProjection<T>.GetWithProjection<Dto>()
        {
            throw new NotImplementedException();
        }
    }
}
