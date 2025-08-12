namespace Catalog.Core.Interfaces.GenericRepositoryInterface
{
    public interface IAdd<T>
    {
        public Task<T> AddAsync(T entity);
    }
}
