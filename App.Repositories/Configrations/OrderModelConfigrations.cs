using App.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repositories.Configrations;

public class OrderHeaderModelConfigrations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.AppUser)
            .WithMany().HasForeignKey(fk => fk.AppUserId);

        builder.Property(ph => ph.PhoneNumber).IsRequired();
        builder.Property(s => s.StreetAddress).IsRequired();
        builder.Property(c => c.City).IsRequired();
        builder.Property(s => s.State).IsRequired();
        builder.Property(p => p.PostalCode).IsRequired();
        builder.Property(p => p.Name).IsRequired();
        
        builder.Property(d => d.OrderDate).HasDefaultValueSql("GETDATE()");        
    }
}