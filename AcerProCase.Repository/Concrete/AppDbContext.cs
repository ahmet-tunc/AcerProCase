using AcerProCase.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace AcerProCase.Repository.Concrete
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<CountryInfo> CountryInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryInfo>(x =>
            {
                x.Property(x => x.Name).IsRequired();
                x.Property(x => x.ShortName).IsRequired();
                x.Property(x => x.CountryCurrency).IsRequired();
                x.Property(x => x.CapitalCity).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
