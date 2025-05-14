namespace Ecommerce.Domain.Interfaces.Base
{
    public interface IBaseRepository<T>:
        ICreateRepository<T>,
        IGetOneRepository<T>,
        IGetAllRepository<T>,
        IUpdateRepository<T>,
        IDeleteOneRepository<T>
    {
    }
}
