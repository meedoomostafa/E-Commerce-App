using App.Models;
using App.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repositories.Configrations;

public class OrderItemModelConfigrations : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(o => o.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(Id => Id.OrderId);
        
        builder.HasOne(p => p.Product).WithMany(o => o.OrderItems).HasForeignKey(Id => Id.ProductId);
    }
}