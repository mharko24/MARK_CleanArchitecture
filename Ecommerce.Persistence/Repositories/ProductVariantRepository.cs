using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Persistence.Repositories
{
    public class ProductVariantRepository : IProductVariantRepository
    {
        private readonly AppDbContext _db;
        public ProductVariantRepository(
            AppDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(ProductVariant t, CancellationToken cancellationToken)
        {
            await _db.ProductVariants.AddAsync(t);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<ProductVariant>> GetAllAsync()
        {
            return await _db.ProductVariants.ToListAsync();
        }

        public async Task<ProductVariant> GetOneAsync(object id)
        {
            return await _db.ProductVariants.FindAsync(id);
        }

        public async Task UpdateAsync(ProductVariant t, object id, CancellationToken cancellationToken)
        {
            var exist = await GetOneAsync(id);
            if (exist != null)
            {
                _db.Entry(exist).CurrentValues.SetValues(t);
                await _db.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
