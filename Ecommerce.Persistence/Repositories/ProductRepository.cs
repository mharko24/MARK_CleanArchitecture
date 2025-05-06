using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;
        //private readonly 

        public ProductRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Product t,CancellationToken cancellationToken)
        {
            await _db.Products.AddAsync(t);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> GetOneAsync(Guid id)
        {
            return await _db.Products.FirstOrDefaultAsync(x => x.ProductId ==id);
        }
    }
}
