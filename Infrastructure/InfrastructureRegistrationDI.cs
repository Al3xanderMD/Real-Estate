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
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IBasePostRepository, BasePostRepository>();
            services.AddScoped<IPartitioningRepository, PartitioningRepository>();
            services.AddScoped<ILotRepository, LotRepository>();
            services.AddScoped<ILotClassificationRepository, LotClassificationRepository>();
            services.AddScoped<IHotelPensionRepository, HotelPensionRepository>();
            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<IHouseTypeRepository, HouseTypeRepository>();
            services.AddScoped<ICommercialRepository, CommercialRepository>();
            services.AddScoped<ICommercialCategoryRepository, CommercialCategoryRepository>();
            services.AddScoped<ICommercialSpecificRepository, CommercialSpecificRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();

            return services;
        }
    }
}
