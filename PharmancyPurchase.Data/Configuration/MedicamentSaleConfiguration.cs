namespace PharmancyPurchase.Data.Configuration
{
    using Core.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MedicamentSaleConfiguration : IEntityTypeConfiguration<MedicamentSale>
    {
        public void Configure(EntityTypeBuilder<MedicamentSale> builder)
        {
            builder.HasOne(t => t.Medicament).WithMany().HasForeignKey(x => x.MedicamentId).IsRequired();
            builder.HasOne(x => x.Sale).WithMany(u => u.MedicamentSales).HasForeignKey(c => c.SaleId).IsRequired();
        }
    }
}