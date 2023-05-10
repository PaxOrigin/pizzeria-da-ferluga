using DatabaseHandler.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseHandler.Configurations;

internal class OrdersConfiguration : IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> entity)
    {
        entity.HasKey(x => x.Id)
            .HasName("PK_Receipt");
        entity.ToTable("Orders");
    }
}
