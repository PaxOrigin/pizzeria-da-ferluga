using DatabaseHandler.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseHandler.Configurations;

internal class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
{
    public void Configure(EntityTypeBuilder<Receipt> entity)
    {
        entity.HasKey(x => x.Id)
            .HasName("PK_Receipt");
        entity.ToTable("Receipts");

        entity.Property(x => x.Price).HasPrecision(5, 2);
    }
}
