using Domain.Models.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Parsistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(o => o.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .UseIdentityColumn()
            .IsRequired();

        builder.Property(o => o.Number)
            .HasColumnName("number")
            .HasColumnType("varchar(255)");

        builder.Property(o => o.Date)
            .HasColumnName("date")
            .HasColumnType("date");

        builder.Property(o => o.ProviderId)
            .HasColumnName("provider_id")
            .HasColumnType("integer");

        builder.HasOne(o => o.Provider)
            .WithMany(p => p.Orders)
            .HasForeignKey(o => o.ProviderId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(o => new { o.Number, o.ProviderId })
            .IsUnique();
    }
}