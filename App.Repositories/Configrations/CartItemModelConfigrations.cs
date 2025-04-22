using App.Models;
using App.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repositories.Configrations;

public class CartItemModelConfigrations : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(sh => sh.ShoppingCart)
            .WithMany(x => x.Items)
            .HasForeignKey(Id => Id.ShoppingCartId);
        
        builder.HasOne(p => p.Product)
            .WithMany(ca => ca.CartItems)
            .HasForeignKey(Id => Id.ProductId);
    }
}