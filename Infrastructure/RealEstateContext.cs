using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;

namespace Infrastructure
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options) : 
            base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<BasePost> BasePosts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Commercial> Commercials { get; set; }
        public DbSet<CommercialCategory> CommercialCategories { get; set; }
        public DbSet<CommercialSpecific> CommercialSpecifics { get; set; }
        public DbSet<HotelPension> HotelPensions { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<HouseType> HouseTypes { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Partitioning> Partitionings { get; set; }
        //public DbSet<RegAuth> RegAuths { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=RealEstateDB;User Id=postgres;Password=root;");
        //}
    }
}