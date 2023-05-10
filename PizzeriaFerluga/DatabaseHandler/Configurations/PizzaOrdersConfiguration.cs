using DatabaseHandler.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseHandler.Configurations;

public class PizzaOrdersConfiguration : IEntityTypeConfiguration<PizzaOrder>
{
    public void Configure(EntityTypeBuilder<PizzaOrder> entity)
    {
        entity.HasKey(x => x.Id)
            .HasName("PK_PizzaOrders");
        entity.ToTable("Pizza Orders");
        entity.Property(x => x.Price).HasPrecision(5, 2);
    }
}
