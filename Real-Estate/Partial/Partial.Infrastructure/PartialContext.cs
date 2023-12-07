using Microsoft.EntityFrameworkCore;
using Partial.Domain.Entities;

namespace Partial.Infrastructure
{
    public class PartialContext : DbContext
    {
        public PartialContext(DbContextOptions<PartialContext> options)
            : base(options)
        {
        }

        //public DbSet<EntityAlex> Entities { get; set; }
        public DbSet<Book> Books { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=PartialDB;User Id=postgres;Password=root;");
        //}
    }
}
