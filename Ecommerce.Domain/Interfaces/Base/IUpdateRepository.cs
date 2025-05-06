namespace Ecommerce.Domain.Interfaces.Base
{
    public interface IUpdateRepository<T>
    {
        Task UpdateAsync(T t, Guid id,CancellationToken cancellationToken);
    }
}
