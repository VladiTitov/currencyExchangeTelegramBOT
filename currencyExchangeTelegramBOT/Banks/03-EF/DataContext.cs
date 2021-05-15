using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public sealed class DataContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Branches> Branches { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Quotation> Quotations { get; set; }

        public DataContext() =>
            Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            //optionsBuilder.UseSqlite(@"Data Source=..\\banks.db");
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=bankDB;Trusted_Connection=True;");
    }
}
