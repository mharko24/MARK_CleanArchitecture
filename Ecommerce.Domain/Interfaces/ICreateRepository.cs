namespace Ecommerce.Domain.Interfaces
{
    public interface ICreateRepository<T>
    {
        Task CreateAsync(T t);
    }
}
