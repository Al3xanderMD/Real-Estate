using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using RealEstate.Application.Contracts.Interfaces;
using RealEstate.Domain.Common;

namespace Infrastructure
{
    public class RealEstateContext : DbContext
    {
		private readonly ICurrentUserService currentUserService;

        public RealEstateContext(
            DbContextOptions<RealEstateContext> options, ICurrentUserService currentUserService) :
            base(options)
        {
            this.currentUserService = currentUserService;
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<BasePost> BasePosts { get; set; }
        public DbSet<Partitioning> Partitionings { get; set; }
        public DbSet<HotelPension> HotelPensions { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<HouseType> HouseTypes { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<LotClassification> LotClassifications { get; set; }
        public DbSet<Commercial> Commercials { get; set; }
        public DbSet<CommercialCategory> CommercialCategories {  get; set; }
        public DbSet<CommercialSpecific> CommercialSpecifics { get; set; }
        public DbSet<Client> Clients { get; set; }
		public DbSet<Post> Posts { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=RealEstateDB; User Id=postgres; Password=root;");
        //}

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
			foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if(entry.State == EntityState.Added)
                {
					entry.Entity.CreatedBy = currentUserService.GetCurrentClaimsPrincipal()?.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
                    entry.Entity.CreatedDate = DateTime.UtcNow;
				}
				else if (entry.State == EntityState.Modified) // pot modifica si daca creez 
                {
					entry.Entity.LastModifiedBy = currentUserService.GetCurrentClaimsPrincipal()?.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
                    entry.Entity.LastModifiedDate = DateTime.UtcNow;
				}
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}
    }
}