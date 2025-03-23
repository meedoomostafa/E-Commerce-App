using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;

namespace App.Repositories.Configrations;

public class ProductModelConfigrations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(fk => fk.CategoryId);
        builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(fk => fk.CategoryId);
        
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(200);
        builder.Property(x => x.Price).HasColumnType("decimal(6,2)");
        
    }
}