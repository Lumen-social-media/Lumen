using Lumen.Profile.Domain.Aggregates.Communities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lumen.Profile.Infrastructure.Aggregates.Communities;

public sealed class CommunityEntityTypeConfiguration : IEntityTypeConfiguration<Community>
{
    public void Configure(EntityTypeBuilder<Community> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd();

        builder.Property(b => b.OwnerId)
            .HasColumnType("uuid");

        builder.HasOne(b => b.Owner)
            .WithMany(b => b.CreatedCommunities)
            .HasForeignKey(b => b.OwnerId);

        builder.HasMany(b => b.Posts)
            .WithOne(b => b.Community)
            .HasForeignKey(b => b.CommunityId);

        builder.Navigation(b => b.Posts)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
