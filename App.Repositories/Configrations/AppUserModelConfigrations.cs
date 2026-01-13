using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;

namespace App.Repositories.Configrations;

public class AppUserModelConfigrations : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserName).HasMaxLength(20);
        builder.Property(x => x.FirstName).HasMaxLength(15);
        builder.Property(x => x.LastName).HasMaxLength(15);
        builder.Property(x => x.StreetAddress).HasMaxLength(200);
        builder.Property(x => x.City).HasMaxLength(50);
        builder.Property(x => x.State).HasMaxLength(50);

        builder.Ignore(x => x.Role);
    }
}