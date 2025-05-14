namespace Ecommerce.Domain.Interfaces.Base
{
    public interface IGetOneRepository<T>
    {
        Task<T> GetOneAsync(object id);
    }
}
