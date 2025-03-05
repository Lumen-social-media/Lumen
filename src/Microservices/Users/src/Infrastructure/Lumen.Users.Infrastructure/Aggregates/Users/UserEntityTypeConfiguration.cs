using Lumen.Users.Domain.Aggregates.Users;
using Lumen.Users.Domain.Aggregates.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lumen.Users.Infrastructure.Aggregates.Users;

public sealed class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasConversion(userId => userId.Value, id => UserId.Create(id));

        builder.HasIndex(b => b.Email);
        builder.HasIndex(b => b.UserName);

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

        builder.Property(b => b.Gender)
            .HasConversion(new EnumToStringConverter<Gender>());

        builder.Property(b => b.Language)
            .HasConversion(new EnumToStringConverter<Language>());

        builder.Property(b => b.MaritalStatus)
            .HasConversion(new EnumToStringConverter<MaritalStatus>());
    }
}
