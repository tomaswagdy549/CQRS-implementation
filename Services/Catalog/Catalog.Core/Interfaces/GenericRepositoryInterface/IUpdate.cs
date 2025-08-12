namespace Catalog.Core.Interfaces.GenericRepositoryInterface
{
    public interface IUpdate<T>
    {
        T Update(T entity);
    }
}
