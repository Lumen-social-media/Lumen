using Lumen.Users.Domain.Aggregates.Communities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lumen.Users.Infrastructure.Aggregates.Communities;

public sealed class CommunityEntityTypeConfiguration : IEntityTypeConfiguration<Community>
{
    public void Configure(EntityTypeBuilder<Community> builder)
    {
        builder.HasKey(b => b.Id);

        builder.HasMany(b => b.Posts)
            .WithOne(b => b.Community)
            .HasForeignKey(b => b.CommunityId);

        builder.Navigation(b => b.Posts)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
