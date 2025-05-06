using Ecommerce.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Extensions
{
    public static class ServiceCollectionConfiguration
    {
        public static void  AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(Program).Assembly));
        }

        public static void AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(connection, ServerVersion.AutoDetect(connection));
            });

            services.AddScoped<AppDbContext>();
        }

        public static void AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {

        }
    }
}
