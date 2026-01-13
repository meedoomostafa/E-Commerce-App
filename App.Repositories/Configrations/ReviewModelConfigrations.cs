using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;

namespace App.Repositories.Configrations;

public class ReviewModelConfigrations : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.Reviews)
            .HasForeignKey(fk => fk.ProductId);

        builder.HasOne(usr => usr.User)
            .WithMany(rv => rv.Reviews)
            .HasForeignKey(fk => fk.UserId);

        builder.Property(c => c.Comment).HasMaxLength(200);
        builder.Property(c => c.Rating).HasColumnType("TINYINT");

        builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
    }
}