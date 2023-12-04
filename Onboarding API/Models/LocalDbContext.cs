using Microsoft.EntityFrameworkCore;
using Onboarding_API.Models;

namespace OnboardingAPI
{
    public partial class LocalDbContext : DbContext
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options)
      : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
