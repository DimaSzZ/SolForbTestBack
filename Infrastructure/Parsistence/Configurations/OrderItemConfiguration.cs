using Domain.Models.OrderItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Parsistence.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");
        builder.HasKey(oi => oi.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .UseIdentityColumn()
            .IsRequired();

        builder.Property(oi => oi.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(255)");

        builder.Property(oi => oi.Quantity)
            .HasColumnName("quantity")
            .HasColumnType("numeric(18,2)");

        builder.Property(oi => oi.Unit)
            .HasColumnName("unit")
            .HasColumnType("varchar(255)");

        builder.Property(oi => oi.OrderId)
            .HasColumnName("order_id")
            .HasColumnType("integer");

        builder.HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId);
    }
}