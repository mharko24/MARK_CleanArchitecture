namespace Ecommerce.Domain.Interfaces.Base
{
    public interface ICreateRepository<T>
    {
        Task CreateAsync(T t, CancellationToken cancellationToken);
    }
}
