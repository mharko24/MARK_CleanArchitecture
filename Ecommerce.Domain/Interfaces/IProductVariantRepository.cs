using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Base;

namespace Ecommerce.Domain.Interfaces
{
    public interface IProductVariantRepository :
        ICreateRepository<ProductVariant>,
        IGetOneRepository<ProductVariant>,
        IGetAllRepository<ProductVariant>,
        IUpdateRepository<ProductVariant>
    {
    }
}
