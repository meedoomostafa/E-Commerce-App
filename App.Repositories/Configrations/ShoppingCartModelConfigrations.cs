using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repositories.Configrations;

public class ShoppingCartModelConfigrations : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(EntityTypeBuilder<ShoppingCart> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(usr => usr.User)
            .WithOne(sc => sc.ShoppingCart)
            .HasForeignKey<ShoppingCart>(sc => sc.UserId);

        builder.HasMany(x => x.Items).WithOne(x => x.ShoppingCart);
    }
}