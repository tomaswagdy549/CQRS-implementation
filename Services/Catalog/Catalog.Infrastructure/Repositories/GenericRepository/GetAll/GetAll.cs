using Catalog.Core.Interfaces.GenericRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories.GenericRepository.GetAll
{
    public class GetAll<T> : IGetAll<T>
    {
        IQueryable<T> IGetAll<T>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
