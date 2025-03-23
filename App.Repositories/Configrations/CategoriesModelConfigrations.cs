using App.Models;
using App.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Repositories.Configrations;

public class CategoriesModelConfigrations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Products).WithOne(x => x.Category);
        
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(200);
    }
}