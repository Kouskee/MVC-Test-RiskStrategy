using Infrastructure.DataModels;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("CompanyDb").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyNote> Notes { get; set; }
        public DbSet<CompanyOrder> History { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
