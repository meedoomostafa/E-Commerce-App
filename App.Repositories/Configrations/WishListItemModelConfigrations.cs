using App.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repositories.Configrations;

public class WishListItemModelConfigrations : IEntityTypeConfiguration<WishlistItem>
{
    public void Configure(EntityTypeBuilder<WishlistItem> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.Product)
            .WithMany(x => x.WishlistItems)
            .HasForeignKey(fk => fk.ProductId);
        
        builder.HasOne(w => w.Wishlist)
            .WithMany(w => w.Items)
            .HasForeignKey(fk => fk.WishlistId);
    }
}