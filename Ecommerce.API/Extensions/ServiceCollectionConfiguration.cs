using Ecommerce.Application.Abstractions.Products.Command.CreateProduct;
using Ecommerce.Application.Entities;
using Ecommerce.Application.Profiles;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Interfaces.Base;
using Ecommerce.Persistence.Data;
using Ecommerce.Persistence.Repositories;
using Ecommerce.Persistence.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Extensions
{
    public static class ServiceCollectionConfiguration
    {
        public static void  AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly));
            services.AddAutoMapper(typeof(ProductProfile));

        }

        public static void AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(connection, ServerVersion.AutoDetect(connection));
            });

            services.AddScoped<AppDbContext>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped(typeof (IBaseRepository<>),typeof (BaseRepository<>));
            services.AddScoped<IProductVariantRepository, ProductVariantRepository>();
            services.AddIdentity<UserApp, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            
        }

        public static void AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {

        }
    }
}
