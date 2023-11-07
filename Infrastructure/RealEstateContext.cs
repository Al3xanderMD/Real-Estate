using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class RealEstateContext : DbContext
    {
        //public dbset<event> events { get; set; }
        //public dbset<category> categories { get; set; }
        //public dbset<order> orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=RealEstate;User Id=postgres;Password=root;");
        }
    }
}