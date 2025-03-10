using Lumen.Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lumen.Identity.Infrastructure.Users;

public sealed class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(b => b.Id);

        builder.OwnsOne(b => b.UserName, navb =>
        {
            navb.HasIndex(b => b.Value);
            navb.Property(b => b.Value).HasColumnName("UserName");
        });

        builder.OwnsOne(b => b.Name, navb =>
        {
            navb.Property(b => b.Value).HasColumnName("UserName");
        });

        builder.OwnsOne(b => b.Surname, navb =>
        {
            navb.Property(b => b.Value).HasColumnName("UserName");
        });

        builder.OwnsOne(b => b.LastName, navb =>
        {
            navb.Property(b => b.Value).HasColumnName("UserName");
        });

        builder.OwnsOne(b => b.Email, navb =>
        {
            navb.HasIndex(b => b.Value);
            navb.Property(b => b.Value).HasColumnName("Email");
        });

        builder.OwnsOne(b => b.About, navb =>
        {
            navb.Property(b => b.Description).HasColumnName("Description");
            navb.Property(b => b.AvatarUrl).HasColumnName("AvatarUrl");
            navb.Property(b => b.Hometown).HasColumnName("Hometown");
            navb.Property(b => b.BirthDate).HasColumnName("BirthDate");
            navb.Property(b => b.Language).HasColumnName("Language");
            navb.Property(b => b.MaritalStatus).HasColumnName("MaritalStatus");
            navb.Property(b => b.CurrentCity).HasColumnName("CurrentCity");
            navb.Property(b => b.PersonalSite).HasColumnName("PersonalSite");
            navb.Property(b => b.Gender).HasColumnName("Gender");
            navb.Property(b => b.SchoolName).HasColumnName("SchoolName");
            navb.Property(b => b.HasPublicProfile).HasColumnName("HasPublicProfile");
        });
    }
}
