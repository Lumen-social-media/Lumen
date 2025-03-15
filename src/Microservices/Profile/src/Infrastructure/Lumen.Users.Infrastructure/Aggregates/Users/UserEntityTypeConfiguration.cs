using Lumen.Profile.Domain.Aggregates.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lumen.Profile.Infrastructure.Aggregates.Users;

public sealed class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(b => b.Id);

        builder.HasMany(b => b.CreatedCommunities)
            .WithOne(b => b.Owner)
            .HasForeignKey(b => b.OwnerId);

        builder.HasMany(b => b.RootAnswerComments)
            .WithOne(b => b.Owner)
            .HasForeignKey(b => b.OwnerId);

        builder.HasMany(b => b.RootComments)
            .WithOne(b => b.Owner)
            .HasForeignKey(b => b.OwnerId);

        builder.HasMany(b => b.Posts)
            .WithOne(b => b.Owner)
            .HasForeignKey(b => b.OwnerId);

        builder.HasMany(b => b.CommentImages)
            .WithOne(b => b.Owner)
            .HasForeignKey(b => b.OwnerId);

        builder.HasMany(b => b.PostImages)
            .WithOne(b => b.Owner)
            .HasForeignKey(b => b.OwnerId);

        builder.Navigation(b => b.CreatedCommunities)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(b => b.RootAnswerComments)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(b => b.RootComments)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(b => b.CommentImages)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Navigation(b => b.PostImages)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.OwnsOne(b => b.UserName, navb =>
        {
            navb.HasIndex(b => b.Value);
            navb.Property(b => b.Value).HasColumnName("UserName");
        });

        builder.OwnsOne(b => b.Name, navb =>
        {
            navb.Property(b => b.Value).HasColumnName("Name");
        });

        builder.OwnsOne(b => b.Surname, navb =>
        {
            navb.Property(b => b.Value).HasColumnName("Surname");
        });

        builder.OwnsOne(b => b.LastName, navb =>
        {
            navb.Property(b => b.Value).HasColumnName("LastName");
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

            navb.Property(b => b.Language).HasColumnName("Language")
                .HasConversion(new EnumToStringConverter<Language>());

            navb.Property(b => b.MaritalStatus).HasColumnName("MaritalStatus")
                .HasConversion(new EnumToStringConverter<MaritalStatus>());

            navb.Property(b => b.Gender).HasColumnName("Gender")
                .HasConversion(new EnumToStringConverter<Gender>());

            navb.Property(b => b.CurrentCity).HasColumnName("CurrentCity");
            navb.Property(b => b.PersonalSite).HasColumnName("PersonalSite");
            navb.Property(b => b.SchoolName).HasColumnName("SchoolName");
            navb.Property(b => b.HasPublicProfile).HasColumnName("HasPublicProfile");
        });
    }
}
