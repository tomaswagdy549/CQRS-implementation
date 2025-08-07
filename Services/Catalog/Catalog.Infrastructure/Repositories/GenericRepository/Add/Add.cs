using Catalog.Core.Interfaces.GenericRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories.GenericRepository.Add
{
    public class Add<T> : IAdd<T>
    {
        Task<T> IAdd<T>.Add(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
