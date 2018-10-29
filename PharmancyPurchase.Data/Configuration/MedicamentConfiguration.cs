namespace PharmancyPurchase.Data.Configuration
{
    using Core.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
    {

        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(1024);
            builder.Property(x => x.Vendor).HasMaxLength(1024);
            builder.Property(x => x.Description).IsRequired();
        }
    }
}