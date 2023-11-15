using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Application.Contracts;
using RealEstate.Application.Persistence;

namespace Infrastructure
{
    public static class InfrastructureRegistrationDI
    {
        public static IServiceCollection AddInfrastructureToDI(
         this IServiceCollection services,
         IConfiguration configuration)
        {
            services.AddDbContext<RealEstateContext>(
                options =>
                options.UseNpgsql(
                    configuration.GetConnectionString
                    ("RealEstateConnection"),
                    builder =>
                    builder.MigrationsAssembly(
                        typeof(RealEstateContext)
                        .Assembly.FullName)));
            services.AddScoped
                (typeof(IAsyncRepository<>),
                typeof(BaseRepository<>));
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IBasePostRepository, BasePostRepository>();
            services.AddScoped<IPartitioningRepository, PartitioningRepository>();
            services.AddScoped<IHouseTypeRepository, HouseTypeRepository>();
            services.AddScoped<IHouseRepository, HouseRepository>();

            return services;
        }
    }
}
