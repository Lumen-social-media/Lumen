using Lumen.Users.Domain.Aggregates.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lumen.Users.Infrastructure.Aggregates.User;

public sealed class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasMany(b => b.CreatedCommunities)
            .WithOne(b => b.Owner)
            .HasForeignKey(b => b.OwnerId);

        builder.HasMany(b => b.RootAnswerComments)
            .WithOne(b => b.Owner)
            .HasForeignKey(b => b.OwnerId);

        builder.HasMany(b => b.RootComments)
            .WithOne(b => b.Owner)
            .HasForeignKey(b => b.OwnerId);

        builder.Property(b => b.Gender)
            .HasConversion(new EnumToStringConverter<Gender>());

        builder.Property(b => b.Language)
            .HasConversion(new EnumToStringConverter<Language>());

        builder.Property(b => b.MaritalStatus)
            .HasConversion(new EnumToStringConverter<MaritalStatus>());
    }
}
