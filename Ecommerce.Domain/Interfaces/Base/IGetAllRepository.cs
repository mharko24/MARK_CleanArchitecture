using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces.Base
{
    public interface IGetAllRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}
