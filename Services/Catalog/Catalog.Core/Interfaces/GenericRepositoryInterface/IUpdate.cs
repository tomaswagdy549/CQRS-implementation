using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Interfaces.GenericRepositoryInterface
{
    public interface IUpdate<T>
    {
        Task<T> Update(T entity);
    }
}
