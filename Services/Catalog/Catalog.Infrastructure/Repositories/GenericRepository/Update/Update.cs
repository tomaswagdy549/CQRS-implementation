using Catalog.Core.Interfaces.GenericRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories.GenericRepository.Update
{
    public class Update<T> : IUpdate<T>
    {
        Task<T> IUpdate<T>.Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
