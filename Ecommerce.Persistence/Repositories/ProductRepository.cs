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

        public async Task DeleteAsync(object id, CancellationToken cancellationToken)
        {
            var product = await GetOneAsync(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> GetOneAsync(object id)
        {
            return await _db.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product t, object id, CancellationToken cancellationToken)
        {
            var exist = await GetOneAsync(id);
            if(exist != null)
            {
                _db.Products.Entry(t).CurrentValues.SetValues(t);
                await _db.SaveChangesAsync(cancellationToken);

            }
        }
    }
}
