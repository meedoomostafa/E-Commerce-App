using App.Models;
using App.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repositories.Configrations;

public class OrderModelConfigrations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(fk => fk.UserId);
        
        builder.Property(OR => OR.Status).HasConversion<string>();
        builder.Property(d => d.OrderDate).HasDefaultValueSql("GETDATE()");
    }
}