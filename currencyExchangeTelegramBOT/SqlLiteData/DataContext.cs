using Banks._02_Classes;
using Microsoft.EntityFrameworkCore;

namespace SqlLiteData
{
    public class DataContext : DbContext
    {
        public DbSet<Bank> Banks { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Branches> Brancheses { get; set; }

        public DataContext() =>
            Database.EnsureCreated();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseSqlite(@"Data Source=..\converterBD.db");
    }
}
