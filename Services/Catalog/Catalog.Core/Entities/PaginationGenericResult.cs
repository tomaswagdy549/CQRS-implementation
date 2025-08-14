using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Entities
{
    public class PaginationGenericResult<T> where T : IEnumerable
    {
        public int TotalCount { get; set; }
        public T Data { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
