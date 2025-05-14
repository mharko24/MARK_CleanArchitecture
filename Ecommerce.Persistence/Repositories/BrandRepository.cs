namespace Ecommerce.Persistence.Repositories
{
    public class BrandRepository //: IBaseRepository<Brand>//IBrandRepository 
    {
        //private readonly AppDbContext _db;
        //public BrandRepository(
        //    AppDbContext db)
        //{
        //    _db = db;
        //}
        //public async Task CreateAsync(Brand t, CancellationToken cancellationToken)
        //{
        //    await _db.Brands.AddAsync(t);
        //    await _db.SaveChangesAsync(cancellationToken);
        //}

        //public Task DeleteAsync(object id, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<Brand>> GetAllAsync()
        //{
        //    return await _db.Brands.ToListAsync();
        //}

        //public async Task<Brand?> GetOneAsync(object id)
        //{
        //    return await _db.Brands.FindAsync(id);
        //}

        //public async Task UpdateAsync(Brand brand, object id, CancellationToken cancellationToken)
        //{
        //    var existBrand = await GetOneAsync(id);
        //    if (existBrand != null)
        //    {
        //        _db.Entry(existBrand).CurrentValues.SetValues(brand);
        //        await _db.SaveChangesAsync(cancellationToken);
        //    }
        //}
    }
}
