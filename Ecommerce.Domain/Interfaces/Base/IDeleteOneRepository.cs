namespace Ecommerce.Domain.Interfaces.Base
{
    public interface IDeleteOneRepository<T>
    {
        Task DeleteAsync(object id, CancellationToken cancellationToken);
    }
}
