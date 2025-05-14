using Ecommerce.Domain.Interfaces.Base;
using Ecommerce.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Persistence.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T: class
    {
        private readonly AppDbContext _db;
        private readonly DbSet<T> _table;
        public BaseRepository(
            AppDbContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public async Task CreateAsync(T t, CancellationToken cancellationToken)
        {
            await _table.AddAsync(t);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(object id, CancellationToken cancellationToken)
        {
            var exist = await GetOneAsync(id);
            if(exist != null)
            {
                _table.Remove(exist);
                await _db.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetOneAsync(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task UpdateAsync(T t, object id, CancellationToken cancellationToken)
        {
            var exist = await GetOneAsync(id);
            if(exist != null)
            {
                _table.Remove(exist);
                await _db.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
