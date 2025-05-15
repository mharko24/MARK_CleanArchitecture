using Ecommerce.Application.Entities;
using Ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Persistence.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<UserApp> UserApps { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<ProductVariant> ProductVariants { get; set; }
    }
}
