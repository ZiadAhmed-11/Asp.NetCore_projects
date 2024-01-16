using CitiesManagerWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CitiesManagerWebAPI.DataBaseContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) 
        {
            
        }

        public AppDbContext() { }

        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasData(new City() { CityID = Guid.NewGuid(), CityName = "Cairo" });
            modelBuilder.Entity<City>().HasData(new City() { CityID = Guid.NewGuid(), CityName = "Paris" });
        }
    }
}
