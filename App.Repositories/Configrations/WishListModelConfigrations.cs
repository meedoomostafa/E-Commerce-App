using App.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repositories.Configrations;

public class WishListModelConfigrations : IEntityTypeConfiguration<Wishlist>
{
    public void Configure(EntityTypeBuilder<Wishlist> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(w => w.AppUser)
            .WithOne(u => u.Wishlist)
            .HasForeignKey<Wishlist>(fk => fk.UserId);
    }
}