namespace PharmancyPurchase.Data
{
    using Configuration;
    using Core.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<MedicamentSale> MedicamentSales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MedicamentConfiguration());
            modelBuilder.ApplyConfiguration(new SaleConfiguration());
            modelBuilder.ApplyConfiguration(new MedicamentSaleConfiguration());
        }
    }
}