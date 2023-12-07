using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Partial.Application.Persistance;
using Partial.Infrastructure.Repositories;

namespace Partial.Infrastructure
{
    public static class InfrastructureRegistrationDI
    {
        public static IServiceCollection AddInfrastructureToDI(
         this IServiceCollection services,
         IConfiguration configuration)
        {
            services.AddDbContext<PartialContext>(
                options =>
                options.UseNpgsql(
                    configuration.GetConnectionString
                    ("PartialConnection"),
                    builder =>
                    builder.MigrationsAssembly(
                        typeof(PartialContext)
                        .Assembly.FullName)));
            services.AddScoped
                (typeof(IAsyncRepository<>),
                typeof(BaseRepository<>));
            services.AddScoped <IBookRepository, BookRepository>();

            return services;
        }

    }
}
