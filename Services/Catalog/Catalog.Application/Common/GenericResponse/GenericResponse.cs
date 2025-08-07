using System.Net;

namespace Catalog.Application.Common.GenericResponse
{
    public class GenericResponse<T>
    {
        public long TimeCollapsedInMilliSeconds { get; set; }
        public long MemoryUsedInBytes { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public bool IsSucceed
        {
            get
            {
                if ((int)HttpStatusCode >= 400)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
