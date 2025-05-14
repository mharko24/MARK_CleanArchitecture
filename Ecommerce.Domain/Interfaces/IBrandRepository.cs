using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Base;

namespace Ecommerce.Domain.Interfaces
{
    public interface IBrandRepository:
        ICreateRepository<Brand>,
        //IGetOneRepository<Brand>,
        IGetAllRepository<Brand>,
        //IUpdateRepository<Brand>,
        IDeleteOneRepository<Brand>

    {
        Task<Brand?> GetBrandAsync(int id);
        Task UpdateBrandAsync(Brand brand, int id, CancellationToken cancellationToken);
    }
}
