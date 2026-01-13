using App.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repositories.Configrations;

public class OrderItemModelConfigrations : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.OrderHeader)
            .WithMany().HasForeignKey(fk => fk.OrderHeaderId);

        builder.HasOne(x => x.Product)
            .WithMany().HasForeignKey(fk => fk.ProductId);
    }
}